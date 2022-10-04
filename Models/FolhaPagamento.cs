using System;

namespace API.Models
{
    public class FolhaPagamento
    {
        public int Id { get; set; }

        public string ano {get; set;}
        public string mes {get; set;}
        public string cpfFuncionario {get; set;}
        public double valorHora { get; set;}

        public double quantidaDedeHoras {get; set;}

        public double salarioBruto {get; set;}

        public double impostoRenda {get; set;}

        public double impostoINSS {get; set;}

        public double impostoFGTS {get; set;}

        public double salarioLiquido {get; set;}
        public Funcionario funcionario {get; set;}

        public FolhaPagamento(){


        }


        public FolhaPagamento(Funcionario funcionario){


           //IR
           if(this.salarioBruto <= 1.903){
            

            this.salarioLiquido = salarioBruto;

            this.impostoRenda = 0.0;


           }else if(this.salarioBruto >= 1.903 && this.salarioBruto <= 2.826 ){

            
            this.salarioLiquido = this.salarioBruto - (this.salarioBruto - 0.075);
            
            this.impostoRenda = 0.075;

           }else if(this.salarioBruto >= 2.826 && this.salarioBruto <= 3.751){

            this.salarioLiquido = this.salarioBruto - (this.salarioBruto - 0.15);

            this.impostoRenda = 0.015;

           }else if(this.salarioBruto >= 3.751 && this.salarioBruto <= 4664){


               this.salarioLiquido = this.salarioBruto - (this.salarioBruto - 0.22);

               this.impostoRenda = 0.22;

           }else{

                this.salarioLiquido = this.salarioBruto - (this.salarioBruto - 0.27);

                this.impostoRenda = 0.27;

           }


           //INSS
           if(this.salarioBruto <= 1.693){
            

            this.salarioLiquido = this.salarioBruto -( this.salarioBruto * 0.08 );
            
            this.impostoINSS = 0.08;

           }else if(this.salarioBruto >= 1.693 && this.salarioBruto <= 2.822 ){

            
            this.salarioLiquido = this.salarioLiquido - (this.salarioLiquido - 0.09);

            this.impostoINSS = 0.09;


           }else if(this.salarioBruto >= 2.822 && this.salarioBruto <= 5.645){

            this.salarioLiquido = this.salarioLiquido - (this.salarioLiquido - 0.11);

            this.impostoINSS = 0.11;

           }else if(this.salarioBruto > 5.645){


               this.salarioLiquido = this.salarioLiquido - (this.salarioLiquido - 0.22);

               this.impostoINSS = 0.22;

           }

           //FGTS
           this.salarioLiquido =  this.salarioBruto - (this.salarioBruto - 0.08);

         
           this.salarioLiquido = this.salarioBruto - this.impostoINSS - this.impostoRenda;
            


        }
        







    }
}