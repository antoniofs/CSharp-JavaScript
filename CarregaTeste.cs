using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoEcommerce.Models
{
    public class CarregaTeste
    {
        public string valorDefaut = "teste";

        public CarregaTeste() {
            valorDefaut = "teste" ;
        }

        public CarregaTeste(string valorDefaut){
            this.valorDefaut = valorDefaut;
        }

        public string carrega(){
            return valorDefaut;
        }
        public string carrega(string t) {
            return t;
        }
        public string carrega(string t, string a) {
            return string.Format("{0},{1}", t, a);
        }
        public string carrega(decimal t) {
            return t.ToString();
        }
    }
}