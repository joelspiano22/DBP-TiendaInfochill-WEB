﻿using ProyectoDBP_TIENDA.Models;

namespace ProyectoDBP_TIENDA.Service.Interface
{
    public interface IProveedores
    {
        IEnumerable<TbProveedor> GetAllProveedores();
        void Add(TbProveedor proveedor);
        void Update(TbProveedor proveedor);
        void Delete(string id);
        TbProveedor GetProveedor(string id);
    }
}
