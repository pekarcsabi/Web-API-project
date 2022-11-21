﻿using RZQ82V_HFT_2022231.Logic;
using RZQ82V_HFT_2022231.Models;
using RZQ82V_HFT_2022231.Repository;
using System;
using System.Linq;

namespace RZQ82V_HFT_2022231.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FlyingDbContext ctx = new FlyingDbContext();

            PlaneRepository prepo = new PlaneRepository(ctx);
            CompanyRepository crepo = new CompanyRepository(ctx);
            AirPortRepository arepo = new AirPortRepository(ctx);
            FlightRepository frepo = new FlightRepository(ctx);

            PlaneLogic plogic = new PlaneLogic(prepo);
            CompanyLogic clogic = new CompanyLogic(crepo);
            AirPortLogic alogic = new AirPortLogic(arepo);
            FlightLogic flogic = new FlightLogic(frepo);



            //var proba = new AirPort("5#PROBA#1");

            //arepo.Create(proba);

            var asd = flogic.FilghtNumberPerYear();

            var age = plogic.Age(4);

            ;
        }
    }
}
