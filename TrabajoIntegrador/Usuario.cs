/*
 */
using System;

namespace TrabajoIntegrador
{
	/// <summary>
	/// Description of Usuario.
	/// </summary>
	public class Usuario
	{
		//Atributos
		private string nomyape;
		private int dni;
		private DateTime horaInicio;
		private DateTime horaFin;
		private decimal importe;
		
		//Constructor
		public Usuario(string nomyape, int dni, int cantHoras, decimal precioxhs, int hora)
		{
			this.nomyape= nomyape;
			this.dni= dni;
			horaInicio= new DateTime(2021,11,22,hora,0,0 );
			horaFin= horaInicio.AddHours(cantHoras);
			this.importe= cantHoras * precioxhs;
		/*  */ 
		}
		
		//Propiedad
		
		public string NombreyApellido{
			
                get{return this.nomyape; }
                set { this.nomyape= value;}
		}
		
		
		public int Dni{
			
                get{return this.dni; }
                set { this.dni= value;}
		}
		
		public DateTime HoraDeInicio{
			
			get{return horaInicio; }
               
		}
		
		public DateTime HoraDeFin{
			
			get{return horaFin; }
               
		}
		
		
		public decimal Importe{
			
			get{return this.importe; }
               
		}
		
		//verifica segun el horario ingresado, si corresponde el descuento para el cliente
		public void VerificarDescuento(){
			
			if (horaInicio.Hour >= 6 && horaFin.Hour <=9){
				
				this.importe=importe*20/100;
				Console.WriteLine("Se aplico el descuento del 20%");				
			}
			else{
			this.importe= importe;
			Console.WriteLine("No corresponde descuento");
			}
			
		}
		
	}
}
