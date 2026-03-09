class PatientBO{
    public void DisplayPatientDetails(List<Patient> patientlist , string name){
        List<Patient> p1 = (from p in patientlist where p.Name == name select p).ToList();
        int le = p1.Count();
        if(le==0) Console.WriteLine("Patient named {0} not found ",name);
        else{
            Console.WriteLine("Name         Age         Illness        City");
            foreach (Patient x1 in p1)
            {
                Console.WriteLine(x1.ToString());
            }
        }
    }
    public void DisplayYoungestPatientDetails(List<Patient> patientlist){
        int age = (from p in patientlist select p.Age).Min();
        var x = from p in patientlist where p.Age==age select p;
        Console.WriteLine("Name         Age         Illness        City");
        foreach (var x1 in x)
            {
                Console.WriteLine(x1.ToString());
            }
    }
    public void displayPatientsFromCity (List<Patient> patientlist, string city){
        List<Patient> p1 = (from p in patientlist where p.City == city select p).ToList();
        int le = p1.Count();
        if(le==0) Console.WriteLine("No Patient Found From {0} ",city);
        else{
            Console.WriteLine("Name         Age         Illness        City");
            foreach (Patient x1 in p1)
            {
                Console.WriteLine(x1.ToString());
            }
        }
    }
}