using System;
using System.Collections;

namespace TrabajoIntegrador
{
	class Program
	{
		public static void Main(string[] args)
		{
			//Inicio del programa
			Console.WriteLine("Bienvenido al cyber de la UNAJ");
			Console.WriteLine("Por favor, Ingrese el valor por hora");
			
			
			bool error= false;
			decimal valorHora= 0;
			while(!error){
				try{
					valorHora=Decimal.Parse(Console.ReadLine());
					error= true;
				}
				catch (Exception){
					Console.WriteLine("Debe ingresar un valor numerico");
				}
			}
			//Se instancia el ciber con el valor por hora
			Ciber unaj = new Ciber(valorHora);
			Boolean casos= true;
			Console.WriteLine("\n");
			int opc = menu();
			while(casos){				
				switch(opc){
					case 1:						
						unaj.agregarUser(valorHora);
						Console.WriteLine("desea agregar este usuario a una maquina? s/n");
						String resp = Console.ReadLine();
						int verificacion = verificarMaquina(unaj, resp);
						if(verificacion!=0){
							unaj.ocuparMaq(verificacion);							
						}						
						Console.ReadKey();
						Console.Clear();
						opc=menu();
						continue;
						
					case 2:						
						
						Console.WriteLine("Se va a asignar un usuario a una maquina (el usuario debe estar creado)");
						int ver = verificarMaquina(unaj, "s");
						if(ver!=0){
							unaj.ocuparMaq(ver);							
						}
						
						Console.ReadKey();
						Console.Clear();
						opc=menu();
						continue;
						
					case 3:
						Console.WriteLine ("Ingrese el numero de maquina para cerrar sesion: ");
						int cerrarMaq = Int32.Parse(Console.ReadLine());
						unaj.liberarMaquina(cerrarMaq);
						Console.WriteLine ("Se cerro la sesion de la maquina");
						Console.ReadKey();
						Console.Clear();
						opc=menu();
						continue;
						
					case 4:
						Console.WriteLine("Lista de maquinas ocupadas: \n");
						
						
						foreach(Maquina maq in unaj.todasMaq()){
							if(maq.User != null){
								Console.WriteLine("Maquina Nro: {0}", maq.NumeroDeMaquina);
								Console.WriteLine("\n");
							}
						}
						Console.ReadKey();
						Console.Clear();
						opc=menu();
						continue;

					case 5:
						Console.WriteLine("Recaudacion de las maquinas: \n");
						foreach(Maquina maq in unaj.todasMaq()){
							Console.WriteLine("Maquina {0}: $ {1}", maq.NumeroDeMaquina, maq.SumaDeImportes);
							Console.WriteLine("\n");
							}
						Console.ReadKey();
						Console.Clear();
						opc=menu();
						continue;
						
					case 6:
						Console.WriteLine("Lista de usuarios: \n");
						if(unaj.todosUsuarios().Count != 0){
							foreach(Usuario usu in unaj.todosUsuarios()){
								Console.WriteLine("Nombre y apellido: {0}", usu.NombreyApellido);
								Console.WriteLine("Dni: {0}", usu.Dni);
								Console.WriteLine("\n");
							}
						}else{
							Console.WriteLine("No se cargo ningun usuario");
							}
						Console.ReadKey();
						Console.Clear();
						opc=menu();
						continue;
						
					case 7:
						Console.WriteLine("Ingrese el Dni del usuario para eliminar: ");
						int dniEliminar = Int32.Parse(Console.ReadLine());
						unaj.eliminarUsuario(dniEliminar);
						Console.ReadKey();
						Console.Clear();
						opc=menu();
						continue;
						
					case 8:
						Console.WriteLine("Total Recaudado por el Ciber `UNAJ`: \n");
						Console.WriteLine("$ {0}",unaj.Recaudacion);
						Console.ReadKey();
						Console.Clear();
						opc=menu();
						continue;						
						
						
					case 9:
						Console.WriteLine("Ver datos de maquina N°: ");
						int posicion = Int32.Parse(Console.ReadLine());
						Maquina maquinaNumero = unaj.verMaq(posicion);
						Console.WriteLine("\n");
						Console.WriteLine("Usuario de la maquina: {0}",maquinaNumero.User.NombreyApellido);
						Console.WriteLine("DNI N°: {0}",maquinaNumero.User.Dni);
						Console.WriteLine("Hora de inicio: {0}",maquinaNumero.User.HoraDeInicio);
						Console.WriteLine("Hora de fin: {0}", maquinaNumero.User.HoraDeFin);
						Console.WriteLine("Importe a abonar: {0}", maquinaNumero.User.Importe);
						Console.ReadKey();
						Console.Clear();
						opc=menu();
						continue;
						
					case 10:
						casos =false;
						continue;
						
					default :
						Console.WriteLine("La opcion ingresada es incorrecta");
						Console.ReadKey();
						Console.Clear();
						opc=menu();
						continue;
				}
				
			}
			
			
			
		}
		
		//Excepciones creadas
		
		class listaDeMaquinaVacia : Exception{
		public int numero;
		public listaDeMaquinaVacia(int n){
			numero = n;
		}
	}
		class maquinaOcupada : Exception{
			public Usuario user;
		public maquinaOcupada(Usuario u){
			user = u;
		}
	}
		
		public static int verificarMaquina(Ciber maquina, String respuesta){
						int maquinaE=0;	
						Boolean flag = false;
						if(respuesta=="s"){
							int cantMaq= maquina.cantMaquinasLibres();
							try{
								int maquinaElegida= maquinaDispo(cantMaq);
								foreach(Maquina maqui in maquina.todasMaq()){
									if(maqui.NumeroDeMaquina==maquinaElegida){
										flag=true;
										int maquinaDis = usuarioEnMaquinaDispo(maquinaElegida,maqui);
										return maquinaDis;
									}		
								}
							}
							
							catch(listaDeMaquinaVacia ){
								Console.WriteLine("Lo sentimos, por el momento no hay maquinas libres");
								maquinaE=0;
								return maquinaE;
							}
							
							catch(maquinaOcupada ){
								Console.WriteLine("Lo sentimos, la maquina se encuentra ocupada" );
								maquinaE=0;
								return maquinaE;
							}
						}
						
						else{
							Console.WriteLine("volviendo al menu principal");
							flag=true;
						}
						
						if(!flag){Console.WriteLine("la maquina ingresada no existe");}
						return maquinaE;
		}
		
		public static int maquinaDispo(int cantMaquina)
		{
			if(cantMaquina!=0){
				Console.WriteLine("ingrese el nro de maquina que quiere asignar al usuario");
				int nroMaquina = Int32.Parse(Console.ReadLine());
				return nroMaquina;								
								
				}else{
					throw new listaDeMaquinaVacia(cantMaquina);					
				}
			
		}
		public static int usuarioEnMaquinaDispo(int nroDeMaq, Maquina maq)
		{
			if(maq.User==null){
				Console.WriteLine("Esta maquina se encuentra disponible");
				return nroDeMaq;
								
				}else{
					throw new maquinaOcupada(maq.User);					
				}
			
		}
		public static int menu(){
			int opcion=0;
			
			Console.WriteLine("Elija una opcion");
			Console.WriteLine("1. Agregar Usuario");
			Console.WriteLine("2. Ocupar maquina");
			Console.WriteLine("3. Cerrar Maquina");
			Console.WriteLine("4. Ver Maquinas ocupadas");
			Console.WriteLine("5. Ver recaudacion de maquina");
			Console.WriteLine("6. Ver Usuarios");
			Console.WriteLine("7. Eliminar Usuarios");
			Console.WriteLine("8. Total Recaudado");
			Console.WriteLine("9. Ver Maquina");
			Console.WriteLine("10. Salir");
			Console.WriteLine("\n");
			
			bool error=false;
			while(!error){
			try{
				opcion= Int32.Parse(Console.ReadLine());
				error=true;
			}
			catch(Exception){
				Console.WriteLine("opcion incorrecta");
				Console.ReadKey();
				Console.Clear();
				menu();
				}
			}
			
			return opcion;
			
		}
	}
}