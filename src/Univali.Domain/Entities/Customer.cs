using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Univali.Api.Entities;

public class Customer
{
    public int Id {get; set;}
    public string Name {get; set;} = string.Empty;
    public string CPF {get; set;} = string.Empty;
    public ICollection<Address> Addresses {get; set;} = new List<Address>();
}