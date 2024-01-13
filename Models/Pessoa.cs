using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto32.Models{
    public abstract class Pessoa{
        private string _nome;
        private string _dataNascimento;
        private string _genero;
        private string _cpf;

        public string nome { get => _nome; set => _nome = value; }
        public string dataNascimento { get => _dataNascimento; set => _dataNascimento = value; }
        public string cpf { get => _cpf; set => _cpf = value; }
        public string genero { 
            get => _genero; 
            set{
                if(value.ToUpper().Equals("M")){
                    _genero = "Masculino"; // se o valor inserido no "genero" for "m" ou "M", será dado como masculino
                }
                else if(value.ToUpper().Equals("F")){
                    _genero = "Feminino"; // se o valor inserido no "genero" for "f" ou "F", será dado como feminino
                }
                else{
                    _genero = "Preferiu não informar"; // se o valor inserido no "genero" for qualquer outra coisa, entende-se que o usuário preferiu não informar
                }
            }
        }
    }
}