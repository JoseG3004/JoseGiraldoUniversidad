// Servicio de conexión con la API REST ASP.NET Core
const API_BASE_URL = 'http://localhost:5021/api';

class ApiService {
    static getToken() { return localStorage.getItem('token'); }
    static getRole() { return localStorage.getItem('rol'); }
    static setSession(token, rol, usuario) {
        localStorage.setItem('token', token);
        localStorage.setItem('rol', rol);
        localStorage.setItem('usuario', usuario);
    }
    static clearSession() { localStorage.clear(); }
    static isAuthenticated() { return !!ApiService.getToken(); }

    static async request(endpoint, options = {}) {
        const token = ApiService.getToken();
        const headers = { 'Content-Type': 'application/json', ...(options.headers || {}) };
        if (token) headers['Authorization'] = `Bearer ${token}`;

        try {
            const response = await fetch(`${API_BASE_URL}${endpoint}`, { ...options, headers });
            if (response.status === 401) {
                ApiService.clearSession();
                window.location.reload();
                throw new Error('Sesión expirada');
            }
            if (response.status === 403) throw new Error('No tienes permisos.');
            if (response.status === 204) return true;
            
            const data = await response.json();
            if (!response.ok) throw new Error(data.message || 'Error en API');
            return data;
        } catch (error) {
            console.error('API Error:', error);
            throw error;
        }
    }

    static async login(usuario, password) {
        const response = await fetch(`${API_BASE_URL}/Auth/login`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ usuario, password })
        });
        if (!response.ok) {
            const err = await response.text();
            throw new Error(err || 'Usuario o contraseña incorrectos.');
        }
        const data = await response.json();
        ApiService.setSession(data.token, data.rol, usuario);
        return data;
    }

    static async getGranjasPaginadas(municipio = '', clima = '', canal = '', pagina = 1, tamanoPagina = 9) {
        const query = new URLSearchParams({
            municipio: municipio || '',
            clima: clima || '',
            canal: canal || '',
            pagina: pagina.toString(),
            tamanoPagina: tamanoPagina.toString()
        });
        return await ApiService.request(`/Granjas/GetBuscarPaginado?${query.toString()}`);
    }

    static async createGranja(dto) {
        return await ApiService.request('/Granjas/AnadirGranja', { method: 'POST', body: JSON.stringify(dto) });
    }

    static async updateGranja(id, dto) {
        return await ApiService.request(`/Granjas/ActualizarGranja/${id}`, { method: 'PUT', body: JSON.stringify(dto) });
    }

    static async deleteGranja(id) {
        return await ApiService.request(`/Granjas/EliminarGranja/${id}`, { method: 'DELETE' });
    }
}
