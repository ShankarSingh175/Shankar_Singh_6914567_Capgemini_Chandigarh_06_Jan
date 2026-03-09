class Program
{
    static void Main(string[] args)
    {
        Queue<string> ticketQueue = new Queue<string>();
        ticketQueue.Enqueue("Ticket-101: Login Issue");
        ticketQueue.Enqueue("Ticket-102: Payment Failure");
        ticketQueue.Enqueue("Ticket-103: App Crash");
        ticketQueue.Enqueue("Ticket-104: Account Locked");

        Stack<string> actionHistory = new Stack<string>();

        Console.WriteLine("---- Processing Tickets ----");

        for (int i = 0; i < 3; i++)
        {
            if (ticketQueue.Count > 0)
            {
                string ticket = ticketQueue.Dequeue();
                Console.WriteLine("Processing " + ticket);

                actionHistory.Push("Viewed details of " + ticket);
                actionHistory.Push("Updated status of " + ticket);
            }
        }

        Console.WriteLine("\n---- Undo Last Action ----");
        if (actionHistory.Count > 0)
        {
            string undoneAction = actionHistory.Pop();
            Console.WriteLine("Undone Action: " + undoneAction);
        }

        Console.WriteLine("\n---- Remaining Tickets in Queue ----");
        foreach (var ticket in ticketQueue)
        {
            Console.WriteLine(ticket);
        }
    }
}
