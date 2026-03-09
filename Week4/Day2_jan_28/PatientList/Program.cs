class Program
{
    public static void Main(String[] args){
        List<Patient> patientlist = new List<Patient>();
        Console.WriteLine("Enter the number of Patients: ");
        int noOfPatient = int.Parse(Console.ReadLine());
        Patient patient = null;
        string name,illness,city;
        int age;
        for(int i=0; i<noOfPatient;i++){
            Console.WriteLine("Enter Patient Details:");
            Console.WriteLine("Enter the name: ");
            name=Console.ReadLine();
            Console.WriteLine("Enter the age: ");
            age=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the illness: ");
            illness=Console.ReadLine();
            Console.WriteLine("Enter the city: ");
            city=Console.ReadLine();
            patient = new Patient(name,age,illness,city);
            patientlist.Add(patient);
        }
        PatientBO patientbo = new PatientBO();
        int choice;
        string opt;
        do{
            Console.WriteLine("What's your choice: ");
            Console.WriteLine("1. Display Patient Details: ");
            Console.WriteLine("2. Display Youngest Patient: ");
            Console.WriteLine("3. Display Employee From City: ");
            choice=int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                Console.WriteLine("Write the patient's name");
                name = Console.ReadLine();
                patientbo.DisplayPatientDetails(patientlist,name);
                break;
                case 2:
                patientbo.DisplayYoungestPatientDetails(patientlist);
                break;
                case 3:
                Console.WriteLine("Write the patient's city");
                city = Console.ReadLine();
                patientbo.displayPatientsFromCity(patientlist,city);
                break;
                default:
                break;
            }
            Console.WriteLine("Do you want to continue(YES/NO): ");
            opt=Console.ReadLine();
        }while(opt == "YES");
    }
}