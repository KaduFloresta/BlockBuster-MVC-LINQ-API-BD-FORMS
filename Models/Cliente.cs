using System.Linq;
using DbRespositorie;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class ClienteModels
    {
        /* 
            Getters and Setters 
        */
        [Key] // Data Annotations - Main key
        public int IdCliente { get; set; }
        
        [Required] // Mandatory data entry
        public string NomeCliente { get; set; }
        
        [Required]
        public string DataNascimento { get; set; }
        
        [Required]
        public string CpfCliente { get; set; }
        
        [Required]
        public int DiasDevolucao { get; set; }
        
        public List<LocacaoModels> locacoes = new List<LocacaoModels>();

        /// <summary>
        /// Constructor - ClienteModels Object
        /// </summary>
        public ClienteModels(string nomeCliente, string dataNascimento, string cpfCliente, int diasDevolucao)
        {
            NomeCliente = nomeCliente;
            DataNascimento = dataNascimento;
            CpfCliente = cpfCliente;
            DiasDevolucao = diasDevolucao; 
            locacoes = new List<LocacaoModels>();           

            var db = new Context();
            db.Clientes.Add(this);
            db.SaveChanges();
        }
        /// <summary>
        /// 2nd Constructor - ClienteModels Object
        /// Using on Entity Framework DONT REMOVE!!!
        /// </summary>
        public ClienteModels()
        {

        }

        /// <summary>
        ///  To find a customer (LinQ)
        /// </summary>
        public static ClienteModels GetCliente(int idCliente)
        {
            var db = new Context();
            return (from cliente in db.Clientes
                    where cliente.IdCliente == idCliente
                    select cliente).First();
        }

        /// <summary>
        /// Add rent
        /// </summary>
        public void AdicionarLocacao(LocacaoModels locacao)
        {
            locacoes.Add(locacao);
        }     

        /// <summary>
        /// Return customer list from DB
        /// </summary>
        public static List<ClienteModels> GetClientes()
        {
            var db = new Context();
            return db.Clientes.ToList();
        }
    }
}