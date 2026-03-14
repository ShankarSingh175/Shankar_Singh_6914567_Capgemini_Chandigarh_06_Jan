using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
[Table("tblBook")]
public class BookModel
{	
	[Key]
	public int BookId{get;set;}

	public string BName{get;set;}
	public string Category{get;set;}
	public int Price{get;set;}	
}