abstract class Person
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public int Age { get; private set; }

    protected Person(int id, string name, int age)
    {
        Id = id;
        Name = name;
        Age = age;
    }
}
class Patient : Person
{
    private List<MedicalRecord> medicalHistory = new List<MedicalRecord>();

    public Patient(int id, string name, int age)
        : base(id, name, age) { }

    public void AddMedicalRecord(MedicalRecord record)
    {
        medicalHistory.Add(record);
    }

    public void ViewMedicalHistory()
    {
        foreach (var record in medicalHistory)
            record.Display();
    }
}
class Doctor : Person
{
    public string Specialization { get; private set; }

    public Doctor(int id, string name, int age, string specialization)
        : base(id, name, age)
    {
        Specialization = specialization;
    }
}
class Nurse : Person
{
    public string Department { get; private set; }

    public Nurse(int id, string name, int age, string department)
        : base(id, name, age)
    {
        Department = department;
    }
}
class MedicalRecord
{
    private string diagnosis;
    private string treatment;
    private DateTime recordDate;

    public MedicalRecord(string diagnosis, string treatment)
    {
        this.diagnosis = diagnosis;
        this.treatment = treatment;
        recordDate = DateTime.Now;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {recordDate}");
        Console.WriteLine($"Diagnosis: {diagnosis}");
        Console.WriteLine($"Treatment: {treatment}");
        Console.WriteLine("---------------------------");
    }
}
class Appointment
{
    public Patient Patient { get; private set; }
    public Doctor Doctor { get; private set; }
    public DateTime AppointmentDate { get; private set; }

    public Appointment(Patient patient, Doctor doctor, DateTime date)
    {
        Patient = patient;
        Doctor = doctor;
        AppointmentDate = date;
    }

    public void DisplayAppointment()
    {
        Console.WriteLine($"Patient: {Patient.Name}");
        Console.WriteLine($"Doctor: {Doctor.Name} ({Doctor.Specialization})");
        Console.WriteLine($"Date: {AppointmentDate}");
    }
}
class Program
{
    static void Main()
    {
        Patient patient = new Patient(1, "Shankar", 22);
        Doctor doctor = new Doctor(101, "Dr. Mehta", 45, "Cardiology");

        Appointment appointment =
            new Appointment(patient, doctor, DateTime.Now.AddDays(1));

        appointment.DisplayAppointment();

        MedicalRecord record =
            new MedicalRecord("High BP", "Prescribed medication");

        patient.AddMedicalRecord(record);

        Console.WriteLine("\nMedical History:");
        patient.ViewMedicalHistory();
    }
}
