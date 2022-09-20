public static class ServiceTemplateGenerator
{
    public static string WriteServiceClass(string moduleName)
    {

        var stringFile = @"import baseService from '@common/services/base.service';
import store from '@common/store/store';

const ssRoute = window.api_routes.smarAPD_SS_Domain;
const http = baseService(store, ssRoute);
const base = '/" + moduleName + @"';

const apiDef = {
    filter(data, headers) {
        return http.post(`${base}/filter`, data, headers);
    },
    getById(id) {
        return http.get(`${base}/${id}`);
    },
    save(data) {
        return http.post(`${base}`, data);
    },
    update(id, data) {
        return http.put(`${base}/${id}`, data);
    },
    remove(id) {
        return http.delete(`${base}/${id}`);
    },
    massDelete(data) {
        return http.delete(`${base}/massdelete`, data);
    },
};

export default apiDef;";

        return stringFile;

    }
}
