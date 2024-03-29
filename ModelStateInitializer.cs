﻿using SerbRailway.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerbRailway
{
    /// <summary>
    /// Here we generate Mock Data for RoadLine, Timetable and Tickets.
    /// This class is called when a user (Client or Manager) successfully logs in.
    /// </summary>
    internal class ModelStateInitializer
    {
        private readonly DateTime Today = DateTime.Now.Date;
        private List<RoadLine> RoadLines = new List<RoadLine>();
        public ModelStateInitializer()
        {
            InitializeModel();
        }

        public void InitializeModel()
        {
            InitializeRoadLines();
            InitializeTickets();
        }

        private void InitializeTickets()
        {
            Client c1 = new Client("Mirko" ,"Sladojevic", "klijent1@email.com", DateTime.ParseExact("10/10/1960", "dd/MM/yyyy", null), "123");
            Client c2 = new Client("Mira" , "Trifunovic", "klijent2@email.com", DateTime.ParseExact("20/11/1970", "dd/MM/yyyy", null), "123");

            DateTime Today = DateTime.Now;

            List<Ticket> tickets = new List<Ticket>();
            Ticket t1 = new Ticket
            {
                Status = Status.BOUGHT,
                DateSold = Today.AddDays(-7),
                TravelDate = DateTime.ParseExact("06/16/2022","MM/dd/yyyy",null),
                Id = 1,
                Owner = c1,
                Line = RoadLines[0]
            };
            Ticket t2 = new Ticket
            {
                Status = Status.RESERVED,
                DateSold = Today.AddDays(-7),
                TravelDate = DateTime.ParseExact("06/16/2022", "MM/dd/yyyy", null),
                Id = 2,
                Owner = c1,
                Line = RoadLines[3]
            };
            Ticket t3 = new Ticket
            {
                Status = Status.RESERVED,
                DateSold = Today.AddDays(-7),
                TravelDate = DateTime.ParseExact("06/15/2022", "MM/dd/yyyy", null),
                Id = 3,
                Owner = c1,
                Line = RoadLines[4]
            };
            Ticket t4 = new Ticket
            {
                Status = Status.BOUGHT,
                DateSold = Today.AddDays(-7),
                TravelDate = DateTime.ParseExact("06/17/2022", "MM/dd/yyyy", null),
                Id = 4,
                Owner = c1,
                Line = RoadLines[4]
            };
            Ticket t5 = new Ticket
            {
                Status = Status.RESERVED,
                DateSold = Today.AddDays(-7),
                TravelDate = DateTime.ParseExact("06/16/2022", "MM/dd/yyyy", null),
                Id = 5,
                Owner = c1,
                Line = RoadLines[2]
            };
            Ticket t6 = new Ticket
            {
                Status = Status.BOUGHT,
                DateSold = Today.AddDays(-7),
                TravelDate = DateTime.ParseExact("06/16/2022", "MM/dd/yyyy", null),
                Id = 6,
                Owner = c2,
                Line = RoadLines[1]
            };
            Ticket t7 = new Ticket
            {
                Status = Status.BOUGHT,
                DateSold = Today.AddDays(-7),
                TravelDate = DateTime.ParseExact("06/16/2022", "MM/dd/yyyy", null),
                Id = 7,
                Owner = c2,
                Line = RoadLines[0]
            };
            Ticket t8 = new Ticket
            {
                Status = Status.BOUGHT,
                DateSold = Today.AddDays(-7),
                TravelDate = DateTime.ParseExact("06/16/2022", "MM/dd/yyyy", null),
                Id = 8,
                Owner = c2,
                Line = RoadLines[3]
            };
            Ticket t9 = new Ticket
            {
                Status = Status.RESERVED,
                DateSold = Today.AddDays(-7),
                TravelDate = DateTime.ParseExact("06/20/2022", "MM/dd/yyyy", null),
                Id = 9,
                Owner = c2,
                Line = RoadLines[4]
            };
            Ticket t10 = new Ticket
            {
                Status = Status.RESERVED,
                DateSold = Today.AddDays(-7),
                TravelDate = DateTime.ParseExact("06/21/2022", "MM/dd/yyyy", null),
                Id = 10,
                Owner = c2,
                Line = RoadLines[2]
            };

            tickets.Add(t1);
            tickets.Add(t2);
            tickets.Add(t3);
            tickets.Add(t4);
            tickets.Add(t5);
            tickets.Add(t6);
            tickets.Add(t7);
            tickets.Add(t8);
            tickets.Add(t9);
            tickets.Add(t10);

            Ticket.AllTickets = tickets;

        }

        public void InitializeRoadLines()
        {
            List<int> travelDays = new List<int>() { 1,2,3,4,5 };
            List<RoadLine> roads = new List<RoadLine>();
            roads.Add(new RoadLine() 
            {
                LineNumber = 1,
                Origin = Station.AllStations[0],
                Destination = Station.AllStations[1],
                Train = Train.AllTrains[2],
                TravelDays = travelDays,
                TravelStartHour = TimeSpan.FromHours(12),
                ETA = TimeSpan.FromHours(1),
            });
            roads.Add(new RoadLine()
            {
                LineNumber = 2,
                Origin = Station.AllStations[2],
                Destination = Station.AllStations[3],
                Train = Train.AllTrains[1],
                TravelDays = travelDays,
                TravelStartHour = TimeSpan.FromHours(12),
                ETA = TimeSpan.FromHours(2),
            });
            roads.Add(new RoadLine()
            {
                LineNumber = 3,
                Origin = Station.AllStations[4],
                Destination = Station.AllStations[0],
                Train = Train.AllTrains[0],
                TravelDays = travelDays,
                TravelStartHour = TimeSpan.FromHours(12),
                ETA = TimeSpan.FromHours(1),
            });
            roads.Add(new RoadLine()
            {
                LineNumber = 4,
                Origin = Station.AllStations[1],
                Destination = Station.AllStations[3],
                Train = Train.AllTrains[2],
                TravelDays = travelDays,
                TravelStartHour = TimeSpan.FromHours(14),
                ETA = TimeSpan.FromHours(2),
            });
            roads.Add(new RoadLine() 
            {
                LineNumber = 5,
                Origin = Station.AllStations[0],
                Destination = Station.AllStations[2],
                Train = Train.AllTrains[3],
                TravelDays = travelDays,
                TravelStartHour = TimeSpan.FromHours(12),
                ETA = TimeSpan.FromHours(1),
            });

            RoadLines = roads;
            foreach (RoadLine line in roads)
            {
                Timetable.AddRoadline(line);
            }
        }

    }
}
