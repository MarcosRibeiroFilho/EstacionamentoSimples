using System;
using System.Text;
using System.Collections.Generic;

namespace Estacionamento_Simples
{
    class Cadastro
    {
        // Atributos
        private string nome;
        private int id;
        private string phone;
        private string placa;
        private string modelo;
        private string cor;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public string Placa
        {
            get { return placa; }
            set {placa = value; }
        }

        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }

        public string Cor
        {
            get { return cor; }
            set { cor = value; }
        }

        public void cadastrar(int ident)
        {
            Console.Clear();
            Console.WriteLine("\tCADASTRO DE USUARIO");
            Console.Write("Digite o nome do usuario: ");
            Nome = Console.ReadLine();
            Id = ident;
            Console.Write("\nDigite o telefone do usuario: ");
            Phone = Console.ReadLine();
            Console.Write("\nDigite a placa do veiculo : ");
            Placa = Console.ReadLine();
            Console.Write("\nDigite o modelo do veiculo : ");
            Modelo = Console.ReadLine();
            Console.Write("\nDigite a cor do veiculo : ");
            Cor = Console.ReadLine();

        }

        public void editaCadastro()
        {

            Console.Write("\n\nDigite o nome do usuario: ");
            Nome = Console.ReadLine();
            Console.Write("Digite o telefone do usuario: ");
            Phone = Console.ReadLine();
            Console.Write("Digite a placa do veiculo : ");
            Placa = Console.ReadLine();
            Console.Write("Digite o modelo do veiculo : ");
            Modelo = Console.ReadLine();
            Console.Write("Digite a cor do veiculo : ");
            Cor = Console.ReadLine();

        }




    }

    class Vaga
    {
        public int[] id2= new int[18] {0,32,0,13,0,14,0,0,0,15,0,0,0,10,0,18,0,0};
        private string hora;

        public void Entra()
        {
            int ncar = ContaVaga();
            if (ncar < 18)
            {
                Console.WriteLine("ENTRADA DE VEICULO");
                Console.Write("Digite o ID: ");
                int num = int.Parse(Console.ReadLine());

                for (int i = 0; i < 18; i++)
                {
                    if (id2[i] == 0)
                    {
                        id2[i] = num;
                        return;
                    }
                }
            }
            else
                Console.WriteLine("\tESTACIONAMENTO LOTADO");
        }

        public void Sai()
        {
            int ncar = ContaVaga();

            if (ncar > 0)
            {
                Console.WriteLine("SAIDA DE VEICULO");
                Console.Write("Digite o ID: ");
                int num = int.Parse(Console.ReadLine());
                bool encontra = false;

                for (int i = 0; i < 18; i++)
                {
                    if (id2[i] == num)
                    {
                        id2[i] = 0;
                        encontra = true;
                        return;
                    }
                }

                if (!encontra)
                    Console.WriteLine("Veiculo nao encontrado");
            }
            else
                Console.WriteLine("Estacionamento vazio\n");

        }

        public void Verifica()
        {
            int ncar = ContaVaga();
            if(ncar > 0)
            {
                Console.WriteLine("Os veiculos estacionados possuem os seguintes IDs:");
                Console.Write("[ ");
                foreach (int car in id2)
                {
                    if(car!=0)
                       Console.Write("{0}  ", car);
                }
                Console.WriteLine("]");
            }
        }

        public int ContaVaga()
        {
            int cont = 0;

            for (int i = 0; i < 18; i++)
            {
                if (id2[i] != 0)
                    cont++;
            }

            return cont;
        }

        public void Imprime()
        {
            Console.WriteLine("\n");
            Console.WriteLine("   ====================================================");
            for (int j = 0; j < 2; j++)
            {
                Console.Write("   ||");
                for (int i = 0; i < 10; i++)
                {
                    if (id2[i] == 0)
                        Console.Write("   ||");
                    else
                        Console.Write(" X ||");
                }
                Console.Write("\n");
            }
            Console.WriteLine("   ||                                                ||");
            Console.WriteLine("   ||                                                ||");
            Console.WriteLine("   ||                                                ||");
            for (int j = 0; j < 2; j++)
            {
                Console.Write("   ||        ||");
                for (int i = 10; i < 18; i++)
                {
                    if (id2[i] == 0)
                        Console.Write("   ||");
                    else
                        Console.Write(" X ||");
                }
                Console.Write("\n");
            }
            Console.WriteLine("   ||        ||========================================");
            //Console.WriteLine("\t  Estacionamento possui " + (18 - ContaVaga()) + " vagas restantes.");
            Console.WriteLine("\n");
        }

        public void ImprimeConsulta()
        {
            Console.WriteLine("\n");
            Console.WriteLine("  ==============================================================");
            Console.Write("  ||");
            for (int i = 0; i < 10; i++)
            {
                if (id2[i] == 0)
                   Console.Write("    ||");
                else
                   Console.Write(" {0:00} ||", id2[i]);
            }
            Console.Write("\n");
            
            Console.WriteLine("  ||                                                          ||");
            Console.WriteLine("  ||                                                          ||");
            Console.WriteLine("  ||                                                          ||");
            
            Console.Write("  ||          ||");
            for (int i = 10; i < 18; i++)
            {
                 if (id2[i] == 0)
                    Console.Write("    ||");
                 else
                    Console.Write(" {0:00} ||", id2[i]);
            }
            Console.Write("\n");
            
            Console.WriteLine("  ||          ||================================================");
            Console.WriteLine("\t        Estacionamento possui " + (18 - ContaVaga()) + " vagas restantes.");
            Console.WriteLine("\n");
        }

    }
}
