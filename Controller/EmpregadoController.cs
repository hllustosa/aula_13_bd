using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teste_aula_13.Model;
using teste_aula_13.Repositorio;

namespace teste_aula_13.Controller
{
    public class EmpregadoController
    {
        private EmpregadoRepositorio EmpregadoRepositorio;

        public EmpregadoController(EmpregadoRepositorio empregadoRepositorio)
        {
            this.EmpregadoRepositorio = empregadoRepositorio;
        }

        public bool Salvar(Empregado empregado)
        {
            try
            {
                EmpregadoRepositorio.Salvar(empregado);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<Empregado> Recuperar()
        {
            try
            {
                return EmpregadoRepositorio.RecuperarEmpregados();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
