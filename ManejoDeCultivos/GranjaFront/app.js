document.addEventListener('DOMContentLoaded', () => {
    checkAuthState();

    document.getElementById('login-form').addEventListener('submit', handleLogin);
    document.getElementById('logout-btn').addEventListener('click', handleLogout);

    // Eventos de Filtros en vivo
    document.getElementById('filter-nombre').addEventListener('input', filtrarLocalmente);
    document.getElementById('filter-municipio').addEventListener('change', () => cargarGranjas(1));
    document.getElementById('filter-producto').addEventListener('change', () => cargarGranjas(1));
    document.getElementById('filter-clima').addEventListener('change', () => cargarGranjas(1));
    document.getElementById('filter-canal').addEventListener('change', () => cargarGranjas(1));
    document.getElementById('filter-tipo-cultivo').addEventListener('change', filtrarLocalmente);
    document.getElementById('filter-proceso').addEventListener('change', filtrarLocalmente);
    document.getElementById('filter-ha-min').addEventListener('input', filtrarLocalmente);
    document.getElementById('filter-ha-max').addEventListener('input', filtrarLocalmente);

    // Inicializar botones Chips interactivos
    initChipsButtons('#procesos-chips-container');
    initChipsButtons('#tipos-chips-container');

    document.getElementById('granja-form').addEventListener('submit', handleSaveGranja);
});

let currentPage = 1;
let rawGranjasData = [];

function checkAuthState() {
    const loginContainer = document.getElementById('login-container');
    const appContainer = document.getElementById('app-container');

    if (ApiService.isAuthenticated()) {
        loginContainer.classList.add('d-none');
        appContainer.classList.remove('d-none');

        const usuario = localStorage.getItem('usuario') || 'Usuario';
        const rol = ApiService.getRole() || 'Usuario';

        document.getElementById('user-display-name').textContent = usuario;
        document.getElementById('user-role-badge').textContent = rol;

        cargarGranjas(1);
    } else {
        loginContainer.classList.remove('d-none');
        appContainer.classList.add('d-none');
    }
}

async function handleLogin(e) {
    e.preventDefault();
    const user = document.getElementById('username').value.trim();
    const pass = document.getElementById('password').value.trim();
    const alertBox = document.getElementById('login-alert');
    const loginBtn = document.getElementById('login-btn');
    const spinner = document.getElementById('login-spinner');

    alertBox.classList.add('d-none');
    loginBtn.disabled = true;
    spinner.classList.remove('d-none');

    try {
        await ApiService.login(user, pass);
        checkAuthState();
    } catch (err) {
        alertBox.textContent = err.message;
        alertBox.classList.remove('d-none');
    } finally {
        loginBtn.disabled = false;
        spinner.classList.add('d-none');
    }
}

function handleLogout() {
    ApiService.clearSession();
    checkAuthState();
}

function switchTab(tab) {
    const sectionInicio = document.getElementById('section-inicio');
    const sectionCatalogo = document.getElementById('section-catalogo');
    const tabInicio = document.getElementById('tab-inicio');
    const tabCatalogo = document.getElementById('tab-catalogo');

    if (tab === 'inicio') {
        sectionInicio.classList.remove('d-none');
        sectionCatalogo.classList.add('d-none');
        tabInicio.classList.add('active');
        tabCatalogo.classList.remove('active');
    } else {
        sectionInicio.classList.add('d-none');
        sectionCatalogo.classList.remove('d-none');
        tabInicio.classList.remove('active');
        tabCatalogo.classList.add('active');
        cargarGranjas(currentPage);
    }
}

async function cargarGranjas(page = 1) {
    currentPage = page;
    const municipio = document.getElementById('filter-municipio').value;
    const clima = document.getElementById('filter-clima').value;
    const canal = document.getElementById('filter-canal').value;

    const container = document.getElementById('fincas-grid-container');
    container.innerHTML = '<div class="col-12 text-center py-5"><div class="spinner-border text-success"></div></div>';

    try {
        const res = await ApiService.getGranjasPaginadas(municipio, clima, canal, page, 9);
        rawGranjasData = res.datos;
        filtrarLocalmente();
        renderPagination(res.paginaActual, res.totalPaginas, res.totalRegistros);
    } catch (err) {
        container.innerHTML = `<div class="col-12 text-center text-danger py-4">${err.message}</div>`;
    }
}

function filtrarLocalmente() {
    const searchNombre = document.getElementById('filter-nombre').value.toLowerCase().trim();
    const searchProducto = document.getElementById('filter-producto').value.toLowerCase().trim();
    const filterTipo = document.getElementById('filter-tipo-cultivo').value.toLowerCase().trim();
    const filterProceso = document.getElementById('filter-proceso').value.toLowerCase().trim();
    const minHa = parseFloat(document.getElementById('filter-ha-min').value) || 0;
    const maxHa = parseFloat(document.getElementById('filter-ha-max').value) || Infinity;

    let filtrados = rawGranjasData.filter(g => {
        const matchNombre = !searchNombre || g.nombre.toLowerCase().includes(searchNombre) || (g.contacto?.nombre || '').toLowerCase().includes(searchNombre) || g.ubicacion.toLowerCase().includes(searchNombre);
        const matchProducto = !searchProducto || g.cultivo.toLowerCase().includes(searchProducto);
        
        const matchTipo = !filterTipo || (g.tipoCultivo || []).some(t => t.toLowerCase().includes(filterTipo));
        const matchProceso = !filterProceso || (g.procesos || []).some(p => p.toLowerCase().includes(filterProceso));
        const matchArea = g.tamanoPlantacion >= minHa && g.tamanoPlantacion <= maxHa;

        return matchNombre && matchProducto && matchTipo && matchProceso && matchArea;
    });

    renderGrid(filtrados);
}

function getIconForCrop(cultivo) {
    const c = cultivo.toLowerCase();
    if (c.includes('café') || c.includes('cafe')) return '☕';
    if (c.includes('aguacate')) return '🥑';
    if (c.includes('fresa')) return '🍓';
    if (c.includes('papa')) return '🥔';
    if (c.includes('tomate')) return '🍊';
    if (c.includes('hortaliza') || c.includes('lechuga') || c.includes('brócoli') || c.includes('acelga') || c.includes('espinaca')) return '🥬';
    if (c.includes('cacao')) return '🍫';
    if (c.includes('cítrico') || c.includes('naranja') || c.includes('mandarina') || c.includes('limón')) return '🍊';
    if (c.includes('zanahoria') || c.includes('remolacha') || c.includes('arracacha')) return '🥕';
    if (c.includes('fríjol') || c.includes('habichuela')) return '🫘';
    if (c.includes('maíz')) return '🌽';
    if (c.includes('uchuva') || c.includes('mora') || c.includes('arándanos') || c.includes('gulupa') || c.includes('granadilla')) return '🫐';
    if (c.includes('hortensias') || c.includes('crisantemos') || c.includes('flores')) return '💐';
    return '🌱';
}

function renderGrid(granjas) {
    const container = document.getElementById('fincas-grid-container');
    const rol = ApiService.getRole();
    const countText = document.getElementById('total-count-text');
    countText.textContent = `${granjas.length} fincas encontradas`;

    container.innerHTML = '';

    if (granjas.length === 0) {
        container.innerHTML = '<div class="col-12 text-center text-muted py-5">No se encontraron fincas con los criterios seleccionados.</div>';
        return;
    }

    granjas.forEach(g => {
        const col = document.createElement('div');
        col.className = 'col-md-6 col-lg-4';

        const icon = getIconForCrop(g.cultivo);

        const climaNormalized = (g.clima || '').toLowerCase();
        let climaBadgeHtml = '<span class="badge bg-info-subtle text-info-emphasis rounded-pill">❄️ Frío</span>';
        if (climaNormalized.includes('caliente')) {
            climaBadgeHtml = '<span class="badge bg-danger-subtle text-danger-emphasis rounded-pill">☀️ Caliente</span>';
        } else if (climaNormalized.includes('templado')) {
            climaBadgeHtml = '<span class="badge bg-warning-subtle text-warning-emphasis rounded-pill">⛅ Templado</span>';
        }

        const adminButtons = rol === 'Admin' ? `
            <div class="mt-3 pt-2 border-top d-flex justify-content-end gap-2" onclick="event.stopPropagation();">
                <button class="btn btn-sm btn-light text-primary rounded-pill px-3" onclick="prepararEdicion(${g.id})"><i class="bi bi-pencil"></i> Editar</button>
                <button class="btn btn-sm btn-light text-danger rounded-pill px-3" onclick="eliminarGranja(${g.id})"><i class="bi bi-trash"></i></button>
            </div>
        ` : '';

        col.innerHTML = `
            <div class="card finca-card p-4 shadow-sm h-100" onclick="verDetalleFinca(${g.id})">
                <div class="d-flex align-items-start gap-3 mb-3">
                    <div class="product-avatar">${icon}</div>
                    <div class="w-100">
                        <div class="d-flex justify-content-between align-items-center">
                            <h5 class="fw-bold text-dark mb-1">${g.nombre}</h5>
                            ${climaBadgeHtml}
                        </div>
                        <p class="text-muted fs-7 mb-0"><i class="bi bi-geo-alt-fill text-danger me-1"></i>${capitalize(g.ubicacion)}</p>
                    </div>
                </div>
                <div class="mb-3 d-flex flex-wrap gap-1">
                    <span class="badge-tag">${capitalize(g.cultivo)}</span>
                    <span class="badge-tag">${capitalize(g.canalVenta)}</span>
                </div>
                <div class="d-flex justify-content-between align-items-center pt-2 mt-auto border-top text-muted fs-7">
                    <span><i class="bi bi-person-fill me-1"></i>${g.contacto?.nombre || 'Propietario'}</span>
                    <span class="fw-bold text-dark-green fs-6">${g.tamanoPlantacion} ha</span>
                </div>
                ${adminButtons}
            </div>
        `;
        col.dataset.granja = JSON.stringify(g);
        container.appendChild(col);
    });
}

function verDetalleFinca(id) {
    const g = rawGranjasData.find(x => x.id === id);
    if (!g) return;

    document.getElementById('det-icon').textContent = getIconForCrop(g.cultivo);
    document.getElementById('det-nombre').textContent = g.nombre;
    document.getElementById('det-ubicacion').innerHTML = `<i class="bi bi-geo-alt-fill me-1"></i>${capitalize(g.ubicacion)}`;
    document.getElementById('det-cultivo').textContent = capitalize(g.cultivo);
    document.getElementById('det-tamano').textContent = `${g.tamanoPlantacion} Hectáreas`;
    document.getElementById('det-ciclos').textContent = `${g.ciclos} Meses de Ciclo`;

    const climaNorm = (g.clima || '').toLowerCase();
    const climaBadge = document.getElementById('det-clima-badge');
    if (climaNorm.includes('caliente')) climaBadge.className = 'badge bg-danger text-white rounded-pill px-3';
    else if (climaNorm.includes('templado')) climaBadge.className = 'badge bg-warning text-dark rounded-pill px-3';
    else climaBadge.className = 'badge bg-info text-white rounded-pill px-3';
    climaBadge.textContent = capitalize(g.clima);

    const canalBadge = document.getElementById('det-canal-badge');
    canalBadge.className = g.canalVenta === 'internacional' ? 'badge bg-primary rounded-pill px-3' : 'badge bg-success rounded-pill px-3';
    canalBadge.textContent = capitalize(g.canalVenta);

    const tiposBox = document.getElementById('det-tipos-container');
    tiposBox.innerHTML = (g.tipoCultivo || []).map(t => `<span class="badge bg-light text-dark border rounded-pill">${capitalize(t)}</span>`).join(' ');

    const procesosBox = document.getElementById('det-procesos-container');
    procesosBox.innerHTML = (g.procesos || []).map(p => `<span class="badge bg-light-green text-green border border-success rounded-pill px-3 py-1.5"><i class="bi bi-check-circle-fill me-1"></i>${capitalize(p)}</span>`).join(' ');

    document.getElementById('det-contacto-nombre').textContent = g.contacto?.nombre || 'No asignado';
    const tel = g.contacto?.telefono || '';
    document.getElementById('det-contacto-telefono').textContent = tel;
    document.getElementById('det-contacto-phone-link').href = tel ? `https://wa.me/${tel.replace(/[^0-9]/g, '')}` : '#';

    const modal = new bootstrap.Modal(document.getElementById('detalleFincaModal'));
    modal.show();
}

function initChipsButtons(containerSelector) {
    const container = document.querySelector(containerSelector);
    if (!container) return;

    container.addEventListener('click', (e) => {
        const btn = e.target.closest('.btn-chip');
        if (btn) {
            btn.classList.toggle('active');
        }
    });
}

function getSelectedChips(containerSelector) {
    const container = document.querySelector(containerSelector);
    if (!container) return [];
    return Array.from(container.querySelectorAll('.btn-chip.active')).map(b => b.dataset.value);
}

function setSelectedChips(containerSelector, valuesList) {
    const container = document.querySelector(containerSelector);
    if (!container) return;
    const values = (valuesList || []).map(v => v.toLowerCase().trim());

    container.querySelectorAll('.btn-chip').forEach(btn => {
        if (values.includes(btn.dataset.value.toLowerCase().trim())) {
            btn.classList.add('active');
        } else {
            btn.classList.remove('active');
        }
    });
}

function renderPagination(pagina, totalPaginas, totalRegistros) {
    const info = document.getElementById('pagination-info');
    info.textContent = `Página ${pagina} de ${totalPaginas} (${totalRegistros} fincas totales)`;

    const container = document.getElementById('pagination-controls');
    container.innerHTML = '';

    for (let i = 1; i <= totalPaginas; i++) {
        const li = document.createElement('li');
        li.className = `page-item ${i === pagina ? 'active' : ''}`;
        li.innerHTML = `<a class="page-link" href="#" onclick="cargarGranjas(${i})">${i}</a>`;
        container.appendChild(li);
    }
}

function capitalize(str) {
    if (!str) return '';
    return str.charAt(0).toUpperCase() + str.slice(1);
}

function limpiarFiltros() {
    document.getElementById('filter-nombre').value = '';
    document.getElementById('filter-municipio').value = '';
    document.getElementById('filter-producto').value = '';
    document.getElementById('filter-clima').value = '';
    document.getElementById('filter-canal').value = '';
    document.getElementById('filter-tipo-cultivo').value = '';
    document.getElementById('filter-proceso').value = '';
    document.getElementById('filter-ha-min').value = '';
    document.getElementById('filter-ha-max').value = '';
    cargarGranjas(1);
}

function abrirModalRegistrar() {
    document.getElementById('granjaModalLabel').innerHTML = '🌱 Registrar Finca en el Oriente';
    document.getElementById('granja-id').value = '';
    document.getElementById('granja-form').reset();
    setSelectedChips('#procesos-chips-container', []);
    setSelectedChips('#tipos-chips-container', []);
    const modal = new bootstrap.Modal(document.getElementById('granjaModal'));
    modal.show();
}

function prepararEdicion(id) {
    const gFound = rawGranjasData.find(x => x.id === id);
    if (!gFound) return;

    document.getElementById('granjaModalLabel').innerHTML = `✏️ Editar Finca #${gFound.id}`;
    document.getElementById('granja-id').value = gFound.id;
    document.getElementById('granja-nombre').value = gFound.nombre;
    document.getElementById('granja-cultivo').value = gFound.cultivo;
    document.getElementById('granja-ubicacion').value = gFound.ubicacion;
    document.getElementById('granja-ciclos').value = gFound.ciclos;
    document.getElementById('granja-tamano').value = gFound.tamanoPlantacion;

    const climaVal = (gFound.clima || 'frio').toLowerCase();
    if (climaVal.includes('caliente')) document.getElementById('clima-caliente').checked = true;
    else if (climaVal.includes('templado')) document.getElementById('clima-templado').checked = true;
    else document.getElementById('clima-frio').checked = true;

    if (gFound.canalVenta === 'internacional') document.getElementById('canal-internacional').checked = true;
    else document.getElementById('canal-nacional').checked = true;

    setSelectedChips('#procesos-chips-container', gFound.procesos);
    setSelectedChips('#tipos-chips-container', gFound.tipoCultivo);

    document.getElementById('contacto-nombre').value = gFound.contacto?.nombre || '';
    document.getElementById('contacto-telefono').value = gFound.contacto?.telefono || '';

    const modal = new bootstrap.Modal(document.getElementById('granjaModal'));
    modal.show();
}

async function handleSaveGranja(e) {
    e.preventDefault();
    const id = document.getElementById('granja-id').value;

    const climaChecked = document.querySelector('input[name="clima-btn-group"]:checked')?.value || 'frio';
    const canalChecked = document.querySelector('input[name="canal-btn-group"]:checked')?.value || 'nacional';
    const procesosSel = getSelectedChips('#procesos-chips-container');
    const tiposSel = getSelectedChips('#tipos-chips-container');

    const dto = {
        nombre: document.getElementById('granja-nombre').value,
        cultivo: document.getElementById('granja-cultivo').value,
        ubicacion: document.getElementById('granja-ubicacion').value,
        ciclos: parseInt(document.getElementById('granja-ciclos').value),
        tamanoPlantacion: parseFloat(document.getElementById('granja-tamano').value),
        clima: climaChecked,
        canalVenta: canalChecked,
        procesos: procesosSel.length > 0 ? procesosSel : ['maduración'],
        tipoCultivo: tiposSel.length > 0 ? tiposSel : ['cultivo permanente'],
        contacto: {
            nombre: document.getElementById('contacto-nombre').value,
            telefono: document.getElementById('contacto-telefono').value
        }
    };

    try {
        if (id) await ApiService.updateGranja(id, dto);
        else await ApiService.createGranja(dto);

        const modalEl = document.getElementById('granjaModal');
        const modal = bootstrap.Modal.getInstance(modalEl);
        modal.hide();

        cargarGranjas(currentPage);
    } catch (err) {
        alert(err.message);
    }
}

async function eliminarGranja(id) {
    if (!confirm(`¿Eliminar la finca #${id}?`)) return;
    try {
        await ApiService.deleteGranja(id);
        cargarGranjas(currentPage);
    } catch (err) {
        alert(err.message);
    }
}
