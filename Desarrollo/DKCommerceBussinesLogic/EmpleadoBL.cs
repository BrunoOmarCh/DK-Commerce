﻿using DKCommerceBussinesEntity;
using DKCommerceDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKCommerceBussinesLogic
{
    public class EmpleadoBL
    {
        public EmpleadoBE SelectById(int idEmpleado)
        {
            try
            {
                var daEmpleado = new EmpleadoDA();
                EmpleadoBE beEmpleado;

                beEmpleado = daEmpleado.SelectById(idEmpleado);
                return beEmpleado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Insert(EmpleadoBE beEmpleado)
        {
            try
            {
                var daEmpleado = new EmpleadoDA();
                daEmpleado.Insert(beEmpleado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Update(int idEmpleado, EmpleadoBE beEmpleado)
        {
            try
            {
                var daEmpleado = new EmpleadoDA();
                daEmpleado.Update(idEmpleado, beEmpleado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(int idEmpleado)
        {
            try
            {
                var daEmpleado = new EmpleadoDA();
                daEmpleado.Delete(idEmpleado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
