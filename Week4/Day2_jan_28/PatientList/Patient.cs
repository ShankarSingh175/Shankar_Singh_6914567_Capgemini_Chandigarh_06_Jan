class Patient{
    private string name;
    private int age;
    private string illness;
    private string city;
    public Patient(string name , int age , string illness , string city){
        this.name = name;
        this.age = age;
        this.illness=illness;
        this.city=city;
    }
    public string Name{
        get{
            return name;
        }
        set{
            name = value;
        }
    }
    public int Age{
        get{
            return age;
        }
        set{
            age = value;
        }
    }
    public string Illness{
        get{
            return illness;
        }
        set{
            illness = value;
        }
    }
    public string City{
        get{
            return city;
        }
        set{
            city = value;
        }
    }
    public override string ToString(){
        return string.Format("{0,-21}{1,-6}{2,-17}{3,-20}",this.name,this.age,this.illness,this.city);
    }
}