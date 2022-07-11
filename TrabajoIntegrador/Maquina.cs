/* 
 */
using System;

namespace TrabajoIntegrador
{
	/// <summary>
	/// Description of Maquina.
	/// </summary>
	public class Maquina
	{
		//Atributos
		private Usuario user;
		private int nromaquina;
		private decimal sumaImportes;
		
		//Constructor
		public Maquina(int nromaquina)
		{
			this.nromaquina= nromaquina;
			this.user= null;
			this.sumaImportes= 0;
			
		}
		
		//Propiedad
		public int NumeroDeMaquina{
			
                get{return this.nromaquina; }
                
		}
		
		public decimal SumaDeImportes{
			
                get{return this.sumaImportes; }
                set { this.sumaImportes += value;}
		}
		
		public Usuario User{
			
                get{return this.user; }
                set { this.user = value;}
		}
		
		
	}
}
