using Capstone.DAL;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace NationalParkCLI
{
    class Menu
    {
        #region variables
        private string connectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=npcampground;Integrated Security=True";

        private NpServicesDAO _dao;

        public int _campgroundId = 0;
        public decimal _dailyFee = 0;
        public string _endDate;
        public string _startDate;
        public DateTime _startDateTime;
        public DateTime _endDateTime;
        public int _timeSpan;
        
        #endregion
        
        #region Park Menu
        /// <summary>
        /// displays a list of national parks
        /// </summary>
        public void ParkMenu()
        {
             _dao = new NpServicesDAO();
            List<Park> listOfParks = _dao.GetParks();
            

            bool proceed = false;
            while (!proceed)
            {
                List<string> listOfParkId = new List<string>();
                Console.Clear();
                foreach (Park park in listOfParks)
                {
                    Console.WriteLine($"{park.park_id}) {park.name}  ");
                    listOfParkId.Add(park.park_id.ToString());

                }
                Console.WriteLine("\nPlease enter the number corresponding to the Park you would like to select.\nOr Press (Q) to quit.");

                string parkId = Console.ReadLine();
                //Makes sure the list and possible selections is expandable.
                try
                { 
                    if (parkId == "q" || parkId == "Q")
                    {
                        proceed = true;
                    }
                    else if (listOfParkId.Contains(parkId))
                    {
                        ParkInfoMenu(parkId);
                    }
                    else
                    {
                        Console.WriteLine("You have made an invalid selection. Press any key to continue.");
                        Console.ReadKey();
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
            }
        }

        #endregion

        #region park info menu
        public void ParkInfoMenu(string parkId)
        {
            
            bool proceed = false;
            while (!proceed)
            {
                Console.Clear();
                List<Park> listOfParks = _dao.GetInfoParks(parkId);

                foreach (Park park in listOfParks)
                {
                    Console.WriteLine($"{park.name}    Park ID:{park.park_id}     Location: {park.location}  \nEst. {park.establishDate}     Park Area:{park.area}   \n\nDESCRIPTION:\n{park.description}\n");
                }
                Console.WriteLine("\nTo select a campground from this park enter 1\nTo go back to main menu enter 2");

                string goBackOrSelectCampground = Console.ReadLine();
                if (goBackOrSelectCampground == "2")
                {
                    proceed = true;
                }
                else if (goBackOrSelectCampground == "1")
                {
                    CampgroundsMenu(parkId);
                }
                else
                {
                    Console.WriteLine("Please enter a valid selection. Press any key to continue");
                    Console.ReadKey();
                }
            }
        }
        #endregion

        #region campgrounds menu
        public void CampgroundsMenu(string campgroundId)
        {
            
            Console.Clear();

            _campgroundId = Convert.ToInt32(campgroundId);
            
            List<Campground> listOfCampgrounds =_dao.getCampgrounds(campgroundId);

            foreach(Campground campground in listOfCampgrounds)
            {
                Console.WriteLine($"{campground.name} Campground ID: {campground.campground_id} \nOpen " +
                    $"From: {CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(campground.open_from_mm)}   " +
                    $"Open until: {CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(campground.open_to_mm)} \n" +
                    $"Daily Fee: ${String.Format("{0:00.00}",campground.daily_fee)}\n\n ");
            }
            Console.WriteLine("1) To make a reservation at one of these campgrounds. \n" +
                              "2) To return to the previous menu press. \n" +
                              "3) To Return to Main Menu press \n" +
                              "Q) To Quit program press");

            string goBackOrSelectCampground = Console.ReadLine();

            bool repeatMethod = true;
            while (repeatMethod)
            {
                if (goBackOrSelectCampground ==  "3")
                {
                    Console.Clear();
                    ParkMenu();
                }
                else if (goBackOrSelectCampground == "2")
                {
                    ParkInfoMenu(campgroundId);
                }
                else if (goBackOrSelectCampground == "1")
                {
                    ReservationMenu();
                }
                else if (goBackOrSelectCampground == "q" || goBackOrSelectCampground == "Q")
                {
                    System.Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Please enter a valid selection.");
                    goBackOrSelectCampground = Console.ReadLine();
                }
            }
        }

        #endregion

        #region Reservation menu

        public void ReservationMenu()
        {
            Console.Clear();
            List<Campground> listOfCampgrounds = _dao.getCampgrounds(_campgroundId.ToString());
            List<int> listOfId = new List<int>();
            foreach (Campground campground in listOfCampgrounds)
            {
                listOfId.Add(campground.campground_id);
                Console.WriteLine($"{campground.name} Campground ID: {campground.campground_id}" +
                    $" \nOpen From (Month): {CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(campground.open_from_mm)}  " +
                    $" Open Til (Month): {CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(campground.open_to_mm)} " +
                    $"\nDaily Fee: ${String.Format("{0:00.00}", campground.daily_fee)}\n\n ");
            }
            
            bool exit = false;
            Console.Write("Please enter the campground ID: ");
            while (!exit)
            {
                string campgroundId = Console.ReadLine();
                try
                {
                    _campgroundId = Convert.ToInt32(campgroundId);
                    
                    if(listOfId.Contains(_campgroundId))
                    {
                        exit = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid ID");
                        exit = false;
                    }
                }
                catch
                {
                    Console.WriteLine("Please enter valid ID");
                }
                
            }
            Console.Write("Please enter start date of your reservation (YYYY-MM-DD): ");
            exit = false;
            while(!exit)
            { 
                _startDate = Console.ReadLine();
                try
                {
                    _startDateTime = Convert.ToDateTime(_startDate);
                    if (_startDateTime < DateTime.UtcNow )
                    {
                        Console.WriteLine("Time doesn't work that way ya goof \n" +
                            "Please enter start date of your reservation (YYYY-MM-DD): ");
                    }
                    else
                    {
                        exit = true;
                    }
                }
                catch
                {
                    Console.WriteLine("Please enter a valid date");
                }
            }
               
                Console.Write("\nPlease enter end date of you reservation (YYYY-MM-DD): ");
            exit = false;
            while (!exit)
            {
                _endDate = Console.ReadLine();
                try
                {
                    _endDateTime = Convert.ToDateTime(_endDate);
                    if (_endDateTime < DateTime.UtcNow || _startDateTime > _endDateTime)
                    {
                        Console.WriteLine("Time doesn't work that way ya goof\n" +
                            "Please enter end date of you reservation (YYYY-MM-DD): ");
                    }
                    else
                    {
                        _timeSpan = ((TimeSpan)(_endDateTime - _startDateTime)).Days;

                        exit = true;
                    }
                }
                catch
                {
                    Console.WriteLine("Please enter a valid date");
                }
            }
            List<Site> listOfSites = _dao.getAvailableSites(_startDate, _endDate, Convert.ToInt32(_campgroundId));
            if (listOfSites.Count > 0)
            {
                Console.Clear();
                foreach (Campground campground in listOfCampgrounds) 
                {
                    foreach (Site site in listOfSites)
                    {
                        if(campground.campground_id == _campgroundId && _timeSpan > 0)
                        Console.WriteLine($"Site ID: {site.site_id} {campground.name} \n\nMax Occupancy " +
                            $"{site.max_occupancy} {(campground.daily_fee*_timeSpan).ToString("C", CultureInfo.CurrentCulture)} \n\n");
                        else if(campground.campground_id == _campgroundId)
                        {
                            Console.WriteLine($"Site ID: {site.site_id} {campground.name} \n\nMax Occupancy " +
                            $"{site.max_occupancy} {(campground.daily_fee).ToString("C", CultureInfo.CurrentCulture)} \n\n");
                        }
                    }
                    
                }
                Console.WriteLine("Sites are available during the seleted dates. \nPress (Y) to make a reservation, press any other key to return to the main menu:  ");
                string reservationResponse = Console.ReadLine();
                    if (reservationResponse == "Y" || reservationResponse == "y")
                    {
                        Console.WriteLine("Which campsite would you like to select?");
                        string siteId = Console.ReadLine();
                        Console.WriteLine("Please enter the name you'd like to make this reservation under: ");
                        string name = Console.ReadLine();
                        string confirmationId = _dao.MakeReservation(siteId, name, _startDate, _endDate);
                        Console.Clear();
                        Console.WriteLine($"Here is your reservation ID {confirmationId}");
                        Console.WriteLine("1 to go to main menu\nAny other key to exit");
                    Console.ReadKey();
                       
                        Environment.Exit(0);
                        
                    }
                    else 
                    {
                        ParkMenu();
                    }
            }
            else
            {
                Console.WriteLine("There are no available sites during those dates. Another selection must be made.\n" +
                                    "Press any key to continue.");
            }

            Console.ReadKey();
        }

        #endregion
    }
}
