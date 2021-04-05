using System;
using System.Globalization;
using System.Collections.Generic;

namespace Estacionamento_Simples
{
    class Program
    {
        static void Main()
        {
            char escolha;
            List<Cadastro> Usuarios = new List<Cadastro>();
            Vaga S1 = new Vaga();
            bool Continua = true;
            int contaId = 0;

            while(Continua)
            {
                Console.Clear();
                Console.WriteLine("\tBEM VINDO AO SISTEMA DE ESTACIONAMENTO\n");
                S1.Imprime();
                Console.WriteLine("\n Escolha uma opcao:");
                Console.WriteLine(" [E] Entrada de veiculo");
                Console.WriteLine(" [S] Saida de veiculo");
                Console.WriteLine(" [V] Verificar vagas");
                Console.WriteLine(" [C] Cadastro de veiculo");
                Console.WriteLine(" [K] Consultar veiculo");
                Console.WriteLine(" [T] Editar Cadastro");
                Console.WriteLine(" [A] Apagar Cadastro");
                Console.WriteLine(" [O] Sair");

                Console.Write("\n Digite sua opcao: ");
                escolha = Console.ReadLine()[0];
                escolha = char.ToUpper(escolha);
                switch (escolha)
                {
                    case 'E': //Entrada de veiculo
                        Console.Clear();
                        S1.Entra();
                        //S1.Imprime();
                        break;

                    case 'S': //Saida de veiculo
                        Console.Clear();
                        S1.Sai();
                        //S1.Imprime();  
                        break;

                    case 'V': //Verificar vaga
                        Console.Clear();
                        S1.Verifica();
                        S1.ImprimeConsulta();
                        Console.WriteLine("\n\tAperte qualquer tecla para retornar ao menu");
                        Console.ReadLine();
                        break;

                    case 'C': //Cadastro de veiculo
                        Usuarios.Add(new Cadastro());
                        Usuarios[contaId].cadastrar(contaId+1);
                        contaId = contaId + 1;
                        Console.WriteLine(contaId);
                        Console.Clear();
                        break;

                    case 'K': //Consultar veiculo
                        
                        Console.WriteLine("Pessoas cadastradas: " + Usuarios.Count);
                        int h = consultar();
                        imprimeCadastro(Usuarios, h);
                        Console.WriteLine("\n\tAperte qualquer tecla para retornar ao menu");
                        Console.ReadLine();
                        break;

                    case 'A': //Apagar Cadastro
                        Console.Clear();
                        Console.WriteLine("\tAPAGAR CADASTRO:");
                        Console.Write("Digite o ID do usuario (ou zero para sair): ");
                        int apaga = int.Parse(Console.ReadLine());
                        int posicao = busca(Usuarios, apaga);
                        if (posicao!=0)
                        {
                            Usuarios.RemoveAt(posicao);
                            Console.WriteLine("\n\tCADASTRO APAGADO");
                            Console.WriteLine("\n\tAperte qualquer tecla para retornar ao menu");
                            Console.ReadLine();
                        }     
                        break;

                    case 'T': //Editar Cadastro
                        Console.Clear();
                        Console.WriteLine("\tEDITAR CADASTRO");
                        Console.Write("Digite o ID do usuario: ");
                        int edita = int.Parse(Console.ReadLine());
                        imprimeCadastro(Usuarios, edita);
                        int num = busca(Usuarios, edita);
                        Usuarios[num].editaCadastro();
                        break;

                    case 'O': //Sair
                        Console.Clear();
                        Console.WriteLine("Sair");
                        Continua = false;
                        break;

                    default:
                        Console.WriteLine("Opcao inválida");
                        break;

                }
                
            }




        }

        public static int consultar()
        {
           
            Console.Clear();
            Console.WriteLine("\tCONSULTAR DADOS DO USUARIO");
            Console.Write("\nDigite o ID do veículo a ser consultado: ");
            int x = int.Parse(Console.ReadLine());

            return x;

        }


        public static void imprimeCadastro(List<Cadastro> User, int ident)
        {

            int n_cadastrados = User.Count;
            bool idEncontrado = false;
            int indice = 0;

            for (int i = 0; i < n_cadastrados; i++)
            {
                if (User[i].Id == ident)
                {
                    idEncontrado = true;
                    indice = i;
                }
            }

            if (idEncontrado)
            {
                Console.WriteLine("\n\nDADOS DO USUARIO:");
                Console.Write("Nome do proprietario: ");
                Console.WriteLine(User[indice].Nome);
                Console.Write("Telefone do proprietario: ");
                Console.WriteLine(User[indice].Phone);
                Console.Write("Placa do veiculo: ");
                Console.WriteLine(User[indice].Placa);
                Console.Write("Modelo do veiculo: ");
                Console.WriteLine(User[indice].Modelo);
                Console.Write("Cor do veiculo: ");
                Console.WriteLine(User[indice].Cor);


            }
            else { Console.WriteLine("\n\tCADASTRO NAO ENCONTRADO"); }



        }


        public static int busca(List<Cadastro> User2, int id_busca)
        {
            int posicaoLista = 0;
            for(int i=0; i<User2.Count; i++)
            {
                if (User2[i].Id == id_busca)
                    posicaoLista = i;
            }

            return posicaoLista;
            
        }


    }
}
