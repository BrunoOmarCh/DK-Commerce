﻿using DKCommerceBussinesEntity;
using DKCommerceDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKCommerceBussinesLogic
{
    public class ProveedorBL
    {
        public ProveedorBE SelectById(int idProveedor)
        {
            try
            {
                var daProveedor = new ProveedorDA();
                ProveedorBE beProveedor;

                beProveedor = daProveedor.SelectById(idProveedor);
                return beProveedor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Insert(ProveedorBE beProveedor)
        {
            try
            {
                var daProveedor = new ProveedorDA();
                daProveedor.Insert(beProveedor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Update(int idProveedor, ProveedorBE beProveedor)
        {
            try
            {
                var daProveedor = new ProveedorDA();
                daProveedor.Update(idProveedor, beProveedor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(int idProveedor)
        {
            try
            {
                var daProveedor = new ProveedorDA();
                daProveedor.Delete(idProveedor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
