﻿using APlus.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APlus.Patient.Booking.Interfaces
{
    public interface ITreatmentTypesService
    {
        public Task<List<TreatmentType>> GetTreatmentTypes();
    }
}