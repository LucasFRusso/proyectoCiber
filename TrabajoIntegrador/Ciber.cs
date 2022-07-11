/*
 */
using System;
using System.Collections;

namespace TrabajoIntegrador
{
	/// <summary>
	/// Description of Ciber.
	/// </summary>
	
	public class Ciber
	{
		//Atributos
		private ArrayList maquina= new ArrayList();
		private ArrayList usuario= new ArrayList();
		private decimal precioDeHora;
		private decimal sumaDescuentos;
		private decimal recaudacion; 
		
		//Constructor
			public Ciber(decimal precioDeHora)
		{
				//Crea 20 maquinas y se agregan al arraylist
				for(int i= 1; i<=20; i++){
					Maquina nueva = new Maquina(i);
					maquina.Add(nueva);
					}
				this.precioDeHora= precioDeHora;
				this.recaudacion= 0;
				sumaDescuentos=0;
		}
			
			//Propiedad
			public decimal PrecioHora{
			
                get{return this.precioDeHora; }
                set { this.precioDeHora = value;}
		}
			
			public decimal SumaDescuento{
			
                get{return this.sumaDescuentos; }
                set { this.sumaDescuentos += value;}
		}	
		
			public decimal Recaudacion{
			
                get{return this.recaudacion; }
                set { this.recaudacion += value;}
		}			
			
			//Metodos
			
			//Cierra el numero de maquina seleccionada
			public void liberarMaquina(int nrocerrar){
				foreach(Maquina maq in maquina){  
					if (maq.NumeroDeMaquina == nrocerrar){
						maq.SumaDeImportes = maq.User.Importe;
						recaudacion+=maq.User.Importe;
						Console.WriteLine("EL usuario {0} debera abonar {1}", maq.User.NombreyApellido ,maq.User.Importe);
						maq.User= null;
					}
				}
			}
			
			//Instancia usuario y lo agrega al arraylist
			public void agregarUser(decimal precioxhora){
				        Console.WriteLine("Ingrese el nombre y apellido del cliente: ");
						String nya= Console.ReadLine();
						Console.WriteLine("\n");
						
						int dni= 0;
						int cantHoras= 0;
						int horaActual= 0;
						bool flag= false;
						while(!flag){
							try{
								Console.WriteLine("Ingrese dni del cliente: ");
								dni= Int32.Parse(Console.ReadLine());
								Console.WriteLine("\n");
								Console.WriteLine("Ingrese la cantidad de horas que va a ocupar una pc el cliente: ");
								cantHoras= Int32.Parse(Console.ReadLine());
								Console.WriteLine("\n");
								Console.WriteLine("ingrese hora actual");
								horaActual= Int32.Parse(Console.ReadLine());
								Console.WriteLine("\n");
								flag= true;
							}
							catch(Exception){
								Console.WriteLine("Debe ingresar numeros");
							}
						}
						Usuario user=new Usuario(nya,dni,cantHoras,precioxhora, horaActual);
						usuario.Add(user);
						Console.WriteLine("usuario creado");
			}
			
			//devuelve arraylist de maquinas
			public ArrayList todasMaq(){
				return maquina;
			}
			
			//devuelve arraylist de usuarios
			public ArrayList todosUsuarios(){
				return usuario;
			}
			
			//cuenta la cantidad de maquinas disponibles
			public int cantMaquinasLibres(){
				int cont = 0;
				foreach (Maquina maq in maquina){
					if(maq.User == null){
						cont ++;
					}
				}
				return cont;
			}
			
			//Ver datos de la maquina seleccionada
			public Maquina verMaq(int i){
				Maquina maqui=null;
				foreach(Maquina maq in maquina){
					if (maq.NumeroDeMaquina == i){
						return maq;
						
					}					
				}
				return maqui;
			}	
						
			//Asigna una maquina 
			public void ocuparMaq(int nroMaq){
				Boolean flag=false;
				foreach (Maquina maq in maquina){
					if (maq.NumeroDeMaquina == nroMaq){						
						Console.WriteLine("Ingrese el DNI del usuario");
						int dni = Int32.Parse(Console.ReadLine());
						foreach (Usuario usu in usuario) {
							if (usu.Dni == dni){
								usu.VerificarDescuento();								
								maq.User= usu;
								Console.WriteLine("Se asigno una maquina al usuario");
								flag=true;
								break;
								
								}							
						}
					}
				}
				if(!flag){
				Console.WriteLine("El Dni ingresado no se encuentra en la lista de usuarios");
				}
			}

			//Elimina un usuario seleccionado
			public void eliminarUsuario(int dni){
				Boolean flag= false;
				foreach(Usuario usu in usuario ){
		 				if (usu.Dni == dni){
		 				usuario.Remove(usu);
		 				Console.WriteLine("El usuario se elimino correctamente");
		 				flag= true;
		 				break;
					}
		 		}
				if(!flag){
				Console.WriteLine("Usuario no encontrado");
				}
		 	}
		 
	}
	}
