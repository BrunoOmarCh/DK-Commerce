﻿using DKCommerceBussinesEntity;
using DKCommerceDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKCommerceBussinesLogic
{
    public class CategoriaBL
    {
        public CategoriaBE SelectById(int idCategoria)
        {
            try
            {
                var daCategoria = new CategoriaDA();
                CategoriaBE beCategoria;

                beCategoria = daCategoria.SelectById(idCategoria);
                return beCategoria;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Insert(CategoriaBE beCategoria)
        {
            try
            {
                var daCategoria = new CategoriaDA();
                daCategoria.Insert(beCategoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Update(int idCategoria, CategoriaBE beCategoria)
        {
            try
            {
                var daCategoria = new CategoriaDA();
                daCategoria.Update(idCategoria, beCategoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(int idCategoria)
        {
            try
            {
                var daCategoria = new CategoriaDA();
                daCategoria.Delete(idCategoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
