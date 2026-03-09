class Program{
			public static void Main()
			{
				int n = int.Parse(Console.ReadLine());

				if (n < 0)
				{
					int[] arr = new int[1];
					arr[0] = -2;
					Console.WriteLine(arr[0]);
				}
				else
				{
					int[] arr1 = new int[n];
				    int[] arr2 = new int[n];
				    int[] arr3 = new int[n];
					for (int i = 0; i < n; i++)
					{
						arr1[i] = int.Parse(Console.ReadLine());
					}
					for (int i = 0; i < n; i++)
					{
						arr2[i] = int.Parse(Console.ReadLine());
					}
					for (int i = 0; i < n; i++)
					{
						if (arr1[i] < 0 || arr2[i] < 0)
						{
							arr3[0] = -1;
							Console.WriteLine(arr3[0]);
							return;
						}
					}
					for (int i = 0; i < n; i++)
					{
						arr3[i] = arr1[i] + arr2[n - i - 1];
					}
					for (int i = 0; i < n; i++)
					{
						Console.Write(arr3[i]);
					}
				}
			}
	}