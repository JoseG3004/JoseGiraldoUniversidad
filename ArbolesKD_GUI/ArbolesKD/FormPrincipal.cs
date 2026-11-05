using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace ArbolesKD
{
    /// <summary>
    /// Interfaz gráfica del sistema de ubicaciones (árbol KD de 2 dimensiones).
    /// Todo el formulario se construye por código: no necesita diseñador.
    /// </summary>
    public class FormPrincipal : Form
    {
        // Panel con doble buffer para que el dibujo no parpadee.
        private class Lienzo : Panel
        {
            public Lienzo()
            {
                SetStyle(ControlStyles.AllPaintingInWmPaint |
                         ControlStyles.UserPaint |
                         ControlStyles.OptimizedDoubleBuffer |
                         ControlStyles.ResizeRedraw, true);
            }
        }

        private const double MUNDO = 100.0; // el mapa va de 0 a 100 en X e Y

        private static readonly Dictionary<string, Color> ColoresCategoria =
            new Dictionary<string, Color>(StringComparer.OrdinalIgnoreCase)
            {
                { "Farmacia",    Color.FromArgb(46, 158, 107) },
                { "Restaurante", Color.FromArgb(242, 140, 40) },
                { "Salud",       Color.FromArgb(214, 69, 69) },
                { "Comercio",    Color.FromArgb(59, 125, 216) },
                { "Parque",      Color.FromArgb(142, 92, 200) },
            };

        private readonly SisUbicacion arbol;

        // --- Estado de la búsqueda ---
        private bool tieneCentro;
        private double[] centro = new double[] { 0, 0 };
        private int modoUsado;
        private double radioUsado;
        private List<Nodo> resultados = new List<Nodo>();
        private readonly HashSet<Nodo> resaltados = new HashSet<Nodo>();
        private readonly Dictionary<Nodo, int> ranking = new Dictionary<Nodo, int>();
        private Nodo seleccionado;

        private List<Nodo> todos = new List<Nodo>();
        private readonly Dictionary<Nodo, TreeNode> mapaArbol = new Dictionary<Nodo, TreeNode>();
        private RectangleF area;
        private string ultimoTip;

        // --- Controles ---
        private Lienzo lienzo;
        private FlowLayoutPanel leyenda;
        private Label lblCoord;
        private ToolTip tip;

        private ComboBox cmbModo, cmbCat;
        private NumericUpDown nudX, nudY, nudRadio;
        private CheckBox chkDivisiones, chkNombres;
        private Button btnBuscar, btnLimpiar;

        private Label lblResumen;
        private ListView lvResultados;
        private TreeView treeKD;
        private Label lblInfoArbol;

        private TextBox txtNombre;
        private ComboBox cmbCatNueva;
        private NumericUpDown nudNuevoX, nudNuevoY;
        private Button btnAgregar;
        private Label lblAgregado;

        public FormPrincipal(SisUbicacion arbol)
        {
            this.arbol = arbol;

            Text = "Sistema de ubicaciones – Árbol KD";
            Font = new Font("Segoe UI", 9f);
            ClientSize = new Size(1180, 740);
            MinimumSize = new Size(960, 600);
            StartPosition = FormStartPosition.CenterScreen;

            ConstruirInterfaz();
            RefrescarTodo();
            cmbModo.SelectedIndex = 0;
        }

        // =====================================================================
        //  CONSTRUCCIÓN DE LA INTERFAZ
        // =====================================================================

        private void ConstruirInterfaz()
        {
            tip = new ToolTip();

            var principal = new TableLayoutPanel();
            principal.Dock = DockStyle.Fill;
            principal.ColumnCount = 2;
            principal.RowCount = 1;
            principal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            principal.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 410f));
            principal.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
            Controls.Add(principal);

            principal.Controls.Add(ConstruirLadoMapa(), 0, 0);
            principal.Controls.Add(ConstruirLadoPanel(), 1, 0);
        }

        private Control ConstruirLadoMapa()
        {
            var izq = new TableLayoutPanel();
            izq.Dock = DockStyle.Fill;
            izq.ColumnCount = 2;
            izq.RowCount = 2;
            izq.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            izq.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150f));
            izq.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
            izq.RowStyles.Add(new RowStyle(SizeType.Absolute, 34f));

            lienzo = new Lienzo();
            lienzo.Dock = DockStyle.Fill;
            lienzo.BackColor = Color.White;
            lienzo.Margin = new Padding(0);
            lienzo.Paint += Lienzo_Paint;
            lienzo.MouseMove += Lienzo_MouseMove;
            lienzo.MouseLeave += Lienzo_MouseLeave;
            lienzo.MouseClick += Lienzo_MouseClick;
            izq.Controls.Add(lienzo, 0, 0);
            izq.SetColumnSpan(lienzo, 2);

            leyenda = new FlowLayoutPanel();
            leyenda.Dock = DockStyle.Fill;
            leyenda.WrapContents = false;
            leyenda.Padding = new Padding(8, 6, 0, 0);
            izq.Controls.Add(leyenda, 0, 1);

            lblCoord = new Label();
            lblCoord.Dock = DockStyle.Fill;
            lblCoord.TextAlign = ContentAlignment.MiddleRight;
            lblCoord.ForeColor = Color.DimGray;
            lblCoord.Text = "Haz clic en el mapa";
            izq.Controls.Add(lblCoord, 1, 1);

            return izq;
        }

        private Control ConstruirLadoPanel()
        {
            var der = new TableLayoutPanel();
            der.Dock = DockStyle.Fill;
            der.ColumnCount = 1;
            der.RowCount = 2;
            der.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            der.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            der.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
            der.Padding = new Padding(0, 6, 8, 8);

            der.Controls.Add(ConstruirBusqueda(), 0, 0);

            var tabs = new TabControl();
            tabs.Dock = DockStyle.Fill;
            tabs.Margin = new Padding(0, 8, 0, 0);

            var tabRes = new TabPage("Resultados");
            tabRes.Controls.Add(ConstruirResultados());
            var tabArbol = new TabPage("Árbol KD");
            tabArbol.Controls.Add(ConstruirVistaArbol());
            var tabAdd = new TabPage("Agregar lugar");
            tabAdd.Controls.Add(ConstruirAgregar());

            tabs.TabPages.Add(tabRes);
            tabs.TabPages.Add(tabArbol);
            tabs.TabPages.Add(tabAdd);
            der.Controls.Add(tabs, 0, 1);

            return der;
        }

        private GroupBox ConstruirBusqueda()
        {
            var gb = new GroupBox();
            gb.Text = "Búsqueda";
            gb.Dock = DockStyle.Fill;
            gb.AutoSize = true;
            gb.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            gb.Padding = new Padding(8, 6, 8, 8);

            var t = new TableLayoutPanel();
            t.Dock = DockStyle.Fill;
            t.AutoSize = true;
            t.ColumnCount = 2;
            t.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 92f));
            t.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));

            cmbModo = new ComboBox();
            cmbModo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbModo.Items.AddRange(new object[]
            {
                "Por radio",
                "5 más cercanas",
                "5 más cercanas por categoría"
            });
            cmbModo.Dock = DockStyle.Fill;
            cmbModo.SelectedIndexChanged += (s, e) => ActualizarControlesModo();

            nudX = CrearNumerico(MUNDO, 50);
            nudY = CrearNumerico(MUNDO, 50);
            nudRadio = CrearNumerico(150, 20);

            cmbCat = new ComboBox();
            cmbCat.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCat.Dock = DockStyle.Fill;

            chkDivisiones = new CheckBox();
            chkDivisiones.Text = "Mostrar divisiones del árbol KD";
            chkDivisiones.AutoSize = true;
            chkDivisiones.CheckedChanged += (s, e) => lienzo.Invalidate();

            chkNombres = new CheckBox();
            chkNombres.Text = "Mostrar todos los nombres";
            chkNombres.AutoSize = true;
            chkNombres.CheckedChanged += (s, e) => lienzo.Invalidate();

            btnBuscar = new Button();
            btnBuscar.Text = "Buscar";
            btnBuscar.AutoSize = true;
            btnBuscar.Padding = new Padding(10, 2, 10, 2);
            btnBuscar.Click += (s, e) => Buscar();
            AcceptButton = btnBuscar;

            btnLimpiar = new Button();
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.AutoSize = true;
            btnLimpiar.Padding = new Padding(10, 2, 10, 2);
            btnLimpiar.Click += (s, e) => LimpiarBusqueda();

            var botones = new FlowLayoutPanel();
            botones.AutoSize = true;
            botones.Dock = DockStyle.Fill;
            botones.Controls.Add(btnBuscar);
            botones.Controls.Add(btnLimpiar);

            AgregarFila(t, "Modo", cmbModo);
            AgregarFila(t, "Tu posición X", nudX);
            AgregarFila(t, "Tu posición Y", nudY);
            AgregarFila(t, "Radio", nudRadio);
            AgregarFila(t, "Categoría", cmbCat);
            AgregarFila(t, "", chkDivisiones);
            AgregarFila(t, "", chkNombres);
            AgregarFila(t, "", botones);

            gb.Controls.Add(t);
            return gb;
        }

        private Control ConstruirResultados()
        {
            var t = new TableLayoutPanel();
            t.Dock = DockStyle.Fill;
            t.ColumnCount = 1;
            t.RowCount = 2;
            t.RowStyles.Add(new RowStyle(SizeType.Absolute, 26f));
            t.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));

            lblResumen = new Label();
            lblResumen.Dock = DockStyle.Fill;
            lblResumen.TextAlign = ContentAlignment.MiddleLeft;
            lblResumen.Text = "Haz clic en el mapa o pulsa Buscar.";
            t.Controls.Add(lblResumen, 0, 0);

            lvResultados = new ListView();
            lvResultados.Dock = DockStyle.Fill;
            lvResultados.View = View.Details;
            lvResultados.FullRowSelect = true;
            lvResultados.HideSelection = false;
            lvResultados.MultiSelect = false;
            lvResultados.GridLines = true;
            lvResultados.Columns.Add("#", 32);
            lvResultados.Columns.Add("Nombre", 150);
            lvResultados.Columns.Add("Categoría", 78);
            lvResultados.Columns.Add("Coord.", 60);
            lvResultados.Columns.Add("Dist.", 50);
            lvResultados.SelectedIndexChanged += (s, e) =>
            {
                if (lvResultados.SelectedItems.Count > 0)
                {
                    seleccionado = lvResultados.SelectedItems[0].Tag as Nodo;
                    lienzo.Invalidate();
                }
            };
            t.Controls.Add(lvResultados, 0, 1);
            return t;
        }

        private Control ConstruirVistaArbol()
        {
            var t = new TableLayoutPanel();
            t.Dock = DockStyle.Fill;
            t.ColumnCount = 1;
            t.RowCount = 2;
            t.RowStyles.Add(new RowStyle(SizeType.Absolute, 40f));
            t.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));

            lblInfoArbol = new Label();
            lblInfoArbol.Dock = DockStyle.Fill;
            lblInfoArbol.TextAlign = ContentAlignment.MiddleLeft;
            t.Controls.Add(lblInfoArbol, 0, 0);

            treeKD = new TreeView();
            treeKD.Dock = DockStyle.Fill;
            treeKD.HideSelection = false;
            treeKD.AfterSelect += (s, e) =>
            {
                seleccionado = e.Node == null ? null : e.Node.Tag as Nodo;
                lienzo.Invalidate();
            };
            t.Controls.Add(treeKD, 0, 1);
            return t;
        }

        private Control ConstruirAgregar()
        {
            var t = new TableLayoutPanel();
            t.Dock = DockStyle.Top;
            t.AutoSize = true;
            t.ColumnCount = 2;
            t.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 92f));
            t.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            t.Padding = new Padding(6);

            txtNombre = new TextBox();
            txtNombre.Dock = DockStyle.Fill;

            cmbCatNueva = new ComboBox();
            cmbCatNueva.DropDownStyle = ComboBoxStyle.DropDown; // permite categorías nuevas
            cmbCatNueva.Dock = DockStyle.Fill;

            nudNuevoX = CrearNumerico(MUNDO, 50);
            nudNuevoY = CrearNumerico(MUNDO, 50);

            btnAgregar = new Button();
            btnAgregar.Text = "Insertar en el árbol";
            btnAgregar.AutoSize = true;
            btnAgregar.Padding = new Padding(10, 2, 10, 2);
            btnAgregar.Click += (s, e) => AgregarLugar();

            lblAgregado = new Label();
            lblAgregado.AutoSize = true;
            lblAgregado.ForeColor = Color.SeaGreen;
            lblAgregado.MaximumSize = new Size(280, 0);

            AgregarFila(t, "Nombre", txtNombre);
            AgregarFila(t, "Categoría", cmbCatNueva);
            AgregarFila(t, "X", nudNuevoX);
            AgregarFila(t, "Y", nudNuevoY);
            AgregarFila(t, "", btnAgregar);
            AgregarFila(t, "", lblAgregado);
            return t;
        }

        private static NumericUpDown CrearNumerico(double max, double valor)
        {
            var n = new NumericUpDown();
            n.DecimalPlaces = 1;
            n.Minimum = 0;
            n.Maximum = (decimal)max;
            n.Increment = 1;
            n.Value = (decimal)valor;
            n.Dock = DockStyle.Left;
            n.Width = 90;
            return n;
        }

        private static void AgregarFila(TableLayoutPanel t, string etiqueta, Control c)
        {
            int fila = t.RowCount;
            t.RowCount = fila + 1;
            t.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            var lbl = new Label();
            lbl.Text = etiqueta;
            lbl.AutoSize = true;
            lbl.Anchor = AnchorStyles.Left;
            lbl.Margin = new Padding(3, 6, 3, 6);
            t.Controls.Add(lbl, 0, fila);

            c.Margin = new Padding(3, 3, 3, 3);
            t.Controls.Add(c, 1, fila);
        }

        // =====================================================================
        //  DATOS Y ACTUALIZACIÓN
        // =====================================================================

        private List<Nodo> RecorrerTodos()
        {
            var lista = new List<Nodo>();
            if (arbol.raiz == null) return lista;
            var pila = new Stack<Nodo>();
            pila.Push(arbol.raiz);
            while (pila.Count > 0)
            {
                Nodo n = pila.Pop();
                lista.Add(n);
                if (n.Derecho != null) pila.Push(n.Derecho);
                if (n.Izquierdo != null) pila.Push(n.Izquierdo);
            }
            return lista;
        }

        private void RefrescarTodo()
        {
            todos = RecorrerTodos();
            RefrescarCategorias();
            ConstruirArbolVisual();
            lienzo.Invalidate();
        }

        private void RefrescarCategorias()
        {
            List<string> cats = todos.Select(n => n.Categoria)
                                     .Distinct(StringComparer.OrdinalIgnoreCase)
                                     .OrderBy(c => c)
                                     .ToList();

            string selActual = cmbCat.SelectedItem as string;
            cmbCat.Items.Clear();
            foreach (string c in cats) cmbCat.Items.Add(c);
            if (selActual != null && cmbCat.Items.Contains(selActual)) cmbCat.SelectedItem = selActual;
            else if (cmbCat.Items.Count > 0) cmbCat.SelectedIndex = 0;

            string textoNueva = cmbCatNueva.Text;
            cmbCatNueva.Items.Clear();
            foreach (string c in cats) cmbCatNueva.Items.Add(c);
            cmbCatNueva.Text = textoNueva;

            leyenda.SuspendLayout();
            leyenda.Controls.Clear();
            foreach (string c in cats)
            {
                int cantidad = todos.Count(n => string.Equals(n.Categoria, c, StringComparison.OrdinalIgnoreCase));
                var l = new Label();
                l.AutoSize = true;
                l.Text = "● " + c + " (" + cantidad + ")";
                l.ForeColor = ColorDe(c);
                l.Margin = new Padding(0, 0, 12, 0);
                leyenda.Controls.Add(l);
            }
            leyenda.ResumeLayout();
        }

        private void ConstruirArbolVisual()
        {
            treeKD.BeginUpdate();
            treeKD.Nodes.Clear();
            mapaArbol.Clear();
            if (arbol.raiz != null)
                treeKD.Nodes.Add(CrearNodoVisual(arbol.raiz, ""));
            treeKD.ExpandAll();
            if (treeKD.Nodes.Count > 0) treeKD.Nodes[0].EnsureVisible();
            treeKD.EndUpdate();

            lblInfoArbol.Text = todos.Count + " nodos · altura " + Altura(arbol.raiz) +
                                "\nraíz: " + (arbol.raiz == null ? "-" : arbol.raiz.Nombre) +
                                "   (◄ izquierdo  ► derecho)";
        }

        private TreeNode CrearNodoVisual(Nodo n, string prefijo)
        {
            string eje = n.Eje == 0 ? "X" : "Y";
            var t = new TreeNode(prefijo + n.Nombre + "  (" + n.Punto[0] + ", " + n.Punto[1] +
                                 ")  · corta en " + eje);
            t.Tag = n;
            t.ForeColor = ColorDe(n.Categoria);
            mapaArbol[n] = t;
            if (n.Izquierdo != null) t.Nodes.Add(CrearNodoVisual(n.Izquierdo, "◄ "));
            if (n.Derecho != null) t.Nodes.Add(CrearNodoVisual(n.Derecho, "► "));
            return t;
        }

        private static int Altura(Nodo n)
        {
            if (n == null) return 0;
            return 1 + Math.Max(Altura(n.Izquierdo), Altura(n.Derecho));
        }

        private static Color ColorDe(string categoria)
        {
            Color c;
            if (categoria != null && ColoresCategoria.TryGetValue(categoria, out c)) return c;
            // Color estable para categorías nuevas
            int h = Math.Abs((categoria ?? "").GetHashCode()) % 360;
            return FromHsv(h, 0.6, 0.75);
        }

        private static Color FromHsv(double h, double s, double v)
        {
            double c = v * s;
            double x = c * (1 - Math.Abs((h / 60.0) % 2 - 1));
            double m = v - c;
            double r = 0, g = 0, b = 0;
            if (h < 60) { r = c; g = x; }
            else if (h < 120) { r = x; g = c; }
            else if (h < 180) { g = c; b = x; }
            else if (h < 240) { g = x; b = c; }
            else if (h < 300) { r = x; b = c; }
            else { r = c; b = x; }
            return Color.FromArgb((int)((r + m) * 255), (int)((g + m) * 255), (int)((b + m) * 255));
        }

        private void ActualizarControlesModo()
        {
            nudRadio.Enabled = cmbModo.SelectedIndex == 0;
            cmbCat.Enabled = cmbModo.SelectedIndex == 2;
        }

        // =====================================================================
        //  ACCIONES
        // =====================================================================

        private void Buscar()
        {
            double[] c = new double[] { (double)nudX.Value, (double)nudY.Value };
            List<Nodo> res;

            switch (cmbModo.SelectedIndex)
            {
                case 0:
                    res = arbol.BuscarEnRadio(c, (double)nudRadio.Value);
                    break;
                case 1:
                    res = arbol.BuscarMasCercanas(c);
                    break;
                default:
                    string cat = cmbCat.SelectedItem as string;
                    if (cat == null)
                    {
                        MessageBox.Show(this, "Elige una categoría.", "Búsqueda",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    res = arbol.BuscarMasCercanasPorCategoria(c, cat);
                    break;
            }

            centro = c;
            tieneCentro = true;
            modoUsado = cmbModo.SelectedIndex;
            radioUsado = (double)nudRadio.Value;
            resultados = res.OrderBy(n => arbol.Magnitud(c, n.Punto)).ToList();

            resaltados.Clear();
            ranking.Clear();
            for (int i = 0; i < resultados.Count; i++)
            {
                resaltados.Add(resultados[i]);
                ranking[resultados[i]] = i + 1;
            }

            lvResultados.BeginUpdate();
            lvResultados.Items.Clear();
            for (int i = 0; i < resultados.Count; i++)
            {
                Nodo n = resultados[i];
                var it = new ListViewItem((i + 1).ToString());
                it.SubItems.Add(n.Nombre);
                it.SubItems.Add(n.Categoria);
                it.SubItems.Add("(" + n.Punto[0] + ", " + n.Punto[1] + ")");
                it.SubItems.Add(arbol.Magnitud(c, n.Punto).ToString("F2"));
                it.ForeColor = ColorDe(n.Categoria);
                it.Tag = n;
                lvResultados.Items.Add(it);
            }
            lvResultados.EndUpdate();

            seleccionado = null;
            if (resultados.Count == 0)
                lblResumen.Text = "No se encontraron ubicaciones.";
            else
                lblResumen.Text = resultados.Count + (resultados.Count == 1 ? " ubicación" : " ubicaciones") +
                                  " desde (" + c[0].ToString("0.#") + ", " + c[1].ToString("0.#") + ")";

            lienzo.Invalidate();
        }

        private void LimpiarBusqueda()
        {
            tieneCentro = false;
            resultados.Clear();
            resaltados.Clear();
            ranking.Clear();
            seleccionado = null;
            lvResultados.Items.Clear();
            lblResumen.Text = "Haz clic en el mapa o pulsa Buscar.";
            lienzo.Invalidate();
        }

        private void AgregarLugar()
        {
            string nombre = txtNombre.Text.Trim();
            string categoria = cmbCatNueva.Text.Trim();
            if (nombre.Length == 0 || categoria.Length == 0)
            {
                MessageBox.Show(this, "Escribe un nombre y una categoría.", "Agregar lugar",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            double x = (double)nudNuevoX.Value;
            double y = (double)nudNuevoY.Value;
            arbol.Insertar((x, y), nombre, categoria);

            todos = RecorrerTodos();
            RefrescarCategorias();
            ConstruirArbolVisual();
            LimpiarBusqueda();

            Nodo nuevo = todos.FirstOrDefault(n => n.Nombre == nombre && n.Punto[0] == x && n.Punto[1] == y);
            seleccionado = nuevo;
            if (nuevo != null && mapaArbol.ContainsKey(nuevo))
            {
                treeKD.SelectedNode = mapaArbol[nuevo];
                mapaArbol[nuevo].EnsureVisible();
            }
            lblAgregado.Text = "“" + nombre + "” insertado en (" + x + ", " + y + ").";
            txtNombre.Clear();
            lienzo.Invalidate();
        }

        // =====================================================================
        //  MAPA: ratón
        // =====================================================================

        private void CalcularArea()
        {
            float mIzq = 40, mAbajo = 30, mArriba = 14, mDer = 16;
            float w = lienzo.ClientSize.Width - mIzq - mDer;
            float h = lienzo.ClientSize.Height - mArriba - mAbajo;
            float lado = Math.Max(50f, Math.Min(w, h));
            area = new RectangleF(mIzq + (w - lado) / 2f, mArriba + (h - lado) / 2f, lado, lado);
        }

        private PointF APantalla(double x, double y)
        {
            return new PointF(area.Left + (float)(x / MUNDO) * area.Width,
                              area.Bottom - (float)(y / MUNDO) * area.Height);
        }

        private Nodo NodoEn(Point p)
        {
            Nodo mejor = null;
            double mejorDist = 10;
            foreach (Nodo n in todos)
            {
                PointF q = APantalla(n.Punto[0], n.Punto[1]);
                double d = Math.Sqrt((q.X - p.X) * (q.X - p.X) + (q.Y - p.Y) * (q.Y - p.Y));
                if (d <= mejorDist) { mejorDist = d; mejor = n; }
            }
            return mejor;
        }

        private void Lienzo_MouseMove(object sender, MouseEventArgs e)
        {
            CalcularArea();
            if (area.Contains(e.Location))
            {
                double x = (e.X - area.Left) / area.Width * MUNDO;
                double y = (area.Bottom - e.Y) / area.Height * MUNDO;
                lblCoord.Text = "x: " + x.ToString("0.0") + "   y: " + y.ToString("0.0");
            }

            Nodo n = NodoEn(e.Location);
            string texto = null;
            if (n != null)
                texto = n.Nombre + "\n" + n.Categoria + " · (" + n.Punto[0] + ", " + n.Punto[1] + ")";
            lienzo.Cursor = n != null ? Cursors.Hand : Cursors.Cross;

            if (texto != ultimoTip)
            {
                ultimoTip = texto;
                if (texto == null) tip.Hide(lienzo);
                else tip.Show(texto, lienzo, e.X + 14, e.Y + 14);
            }
        }

        private void Lienzo_MouseLeave(object sender, EventArgs e)
        {
            ultimoTip = null;
            tip.Hide(lienzo);
        }

        private void Lienzo_MouseClick(object sender, MouseEventArgs e)
        {
            CalcularArea();
            Nodo n = NodoEn(e.Location);
            if (n != null)
            {
                // Clic sobre un lugar: seleccionarlo.
                seleccionado = n;
                if (mapaArbol.ContainsKey(n)) treeKD.SelectedNode = mapaArbol[n];
                foreach (ListViewItem it in lvResultados.Items)
                    it.Selected = ReferenceEquals(it.Tag, n);
                lienzo.Invalidate();
                return;
            }

            if (!area.Contains(e.Location)) return;

            // Clic en espacio libre: nueva posición y búsqueda automática.
            double x = Math.Round((e.X - area.Left) / area.Width * MUNDO, 1);
            double y = Math.Round((area.Bottom - e.Y) / area.Height * MUNDO, 1);
            nudX.Value = (decimal)Math.Max(0, Math.Min(MUNDO, x));
            nudY.Value = (decimal)Math.Max(0, Math.Min(MUNDO, y));
            Buscar();
        }

        // =====================================================================
        //  MAPA: dibujo
        // =====================================================================

        private void Lienzo_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            CalcularArea();

            DibujarCuadricula(g);

            if (chkDivisiones != null && chkDivisiones.Checked && arbol.raiz != null)
                DibujarDivisiones(g, arbol.raiz, 0, MUNDO, 0, MUNDO);

            if (tieneCentro) DibujarBusqueda(g);

            DibujarPuntos(g);

            if (tieneCentro) DibujarCentro(g);
        }

        private void DibujarCuadricula(Graphics g)
        {
            using (var fondo = new SolidBrush(Color.FromArgb(250, 250, 252)))
                g.FillRectangle(fondo, area);

            using (var pen = new Pen(Color.FromArgb(228, 228, 234)))
            using (var txt = new SolidBrush(Color.Gray))
            using (var fuente = new Font("Segoe UI", 7.5f))
            {
                for (int i = 0; i <= 10; i++)
                {
                    float px = area.Left + area.Width * i / 10f;
                    float py = area.Bottom - area.Height * i / 10f;
                    g.DrawLine(pen, px, area.Top, px, area.Bottom);
                    g.DrawLine(pen, area.Left, py, area.Right, py);

                    string s = (i * 10).ToString();
                    SizeF sz = g.MeasureString(s, fuente);
                    g.DrawString(s, fuente, txt, px - sz.Width / 2f, area.Bottom + 3);
                    g.DrawString(s, fuente, txt, area.Left - sz.Width - 3, py - sz.Height / 2f);
                }
            }
            using (var borde = new Pen(Color.FromArgb(170, 170, 180)))
                g.DrawRectangle(borde, area.X, area.Y, area.Width, area.Height);
        }

        private void DibujarDivisiones(Graphics g, Nodo n, double x0, double x1, double y0, double y1)
        {
            if (n == null) return;
            double px = n.Punto[0], py = n.Punto[1];

            if (n.Eje == 0)
            {
                using (var pen = new Pen(Color.FromArgb(150, 59, 125, 216), 1.2f))
                {
                    pen.DashStyle = DashStyle.Dash;
                    g.DrawLine(pen, APantalla(px, y0), APantalla(px, y1));
                }
                DibujarDivisiones(g, n.Izquierdo, x0, px, y0, y1);
                DibujarDivisiones(g, n.Derecho, px, x1, y0, y1);
            }
            else
            {
                using (var pen = new Pen(Color.FromArgb(150, 242, 140, 40), 1.2f))
                {
                    pen.DashStyle = DashStyle.Dash;
                    g.DrawLine(pen, APantalla(x0, py), APantalla(x1, py));
                }
                DibujarDivisiones(g, n.Izquierdo, x0, x1, y0, py);
                DibujarDivisiones(g, n.Derecho, x0, x1, py, y1);
            }
        }

        private void DibujarBusqueda(Graphics g)
        {
            PointF c = APantalla(centro[0], centro[1]);
            GraphicsState estado = g.Save();
            g.SetClip(area);

            if (modoUsado == 0)
            {
                float r = (float)(radioUsado / MUNDO) * area.Width;
                using (var relleno = new SolidBrush(Color.FromArgb(34, 59, 125, 216)))
                using (var borde = new Pen(Color.FromArgb(200, 59, 125, 216), 1.6f))
                {
                    g.FillEllipse(relleno, c.X - r, c.Y - r, 2 * r, 2 * r);
                    g.DrawEllipse(borde, c.X - r, c.Y - r, 2 * r, 2 * r);
                }
            }
            else
            {
                using (var pen = new Pen(Color.FromArgb(150, 90, 90, 100), 1.2f))
                {
                    pen.DashStyle = DashStyle.Dot;
                    foreach (Nodo n in resultados)
                        g.DrawLine(pen, c, APantalla(n.Punto[0], n.Punto[1]));
                }
            }
            g.Restore(estado);
        }

        private void DibujarPuntos(Graphics g)
        {
            bool hayBusqueda = tieneCentro;
            using (var fuente = new Font("Segoe UI", 8f))
            using (var fuenteNegrita = new Font("Segoe UI", 8.5f, FontStyle.Bold))
            {
                // Primero los atenuados, luego los resaltados (quedan por encima).
                foreach (Nodo n in todos.OrderBy(q => resaltados.Contains(q) || ReferenceEquals(q, seleccionado) ? 1 : 0))
                {
                    PointF p = APantalla(n.Punto[0], n.Punto[1]);
                    Color col = ColorDe(n.Categoria);
                    bool esRes = resaltados.Contains(n);
                    bool esSel = ReferenceEquals(n, seleccionado);
                    bool atenuado = hayBusqueda && !esRes && !esSel;
                    float r = esRes || esSel ? 8f : 6f;

                    using (var relleno = new SolidBrush(atenuado ? Color.FromArgb(70, col) : col))
                        g.FillEllipse(relleno, p.X - r, p.Y - r, 2 * r, 2 * r);

                    using (var borde = new Pen(atenuado ? Color.FromArgb(70, Color.White) : Color.White, 1.5f))
                        g.DrawEllipse(borde, p.X - r, p.Y - r, 2 * r, 2 * r);

                    if (esSel)
                    {
                        using (var anillo = new Pen(Color.Black, 2f))
                            g.DrawEllipse(anillo, p.X - r - 3, p.Y - r - 3, 2 * (r + 3), 2 * (r + 3));
                    }

                    bool conNombre = chkNombres.Checked || esRes || esSel;
                    if (conNombre)
                    {
                        string etiqueta = n.Nombre;
                        if (modoUsado != 0 && ranking.ContainsKey(n)) etiqueta = ranking[n] + ". " + etiqueta;
                        Font f = esRes || esSel ? fuenteNegrita : fuente;
                        SizeF sz = g.MeasureString(etiqueta, f);
                        float tx = p.X + r + 3;
                        float ty = p.Y - sz.Height / 2f;
                        if (tx + sz.Width > area.Right) tx = p.X - r - 3 - sz.Width; // que no se salga

                        using (var halo = new SolidBrush(Color.FromArgb(200, 255, 255, 255)))
                            g.FillRectangle(halo, tx, ty, sz.Width, sz.Height);
                        using (var texto = new SolidBrush(atenuado ? Color.Gray : Color.FromArgb(40, 40, 48)))
                            g.DrawString(etiqueta, f, texto, tx, ty);
                    }
                }
            }
        }

        private void DibujarCentro(Graphics g)
        {
            PointF c = APantalla(centro[0], centro[1]);
            using (var pen = new Pen(Color.FromArgb(220, 30, 30), 2.2f))
            {
                g.DrawLine(pen, c.X - 8, c.Y, c.X + 8, c.Y);
                g.DrawLine(pen, c.X, c.Y - 8, c.X, c.Y + 8);
                g.DrawEllipse(pen, c.X - 5, c.Y - 5, 10, 10);
            }
        }
    }
}
