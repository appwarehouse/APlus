using APlus.DataAccess;
using APlus.DataAccess.Models;
using APlus.EmailClient.Models;
using APlus.Patient.Booking.DTOs;
using Itenso.TimePeriod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APlus.Patient.Booking
{
    public static class Extensions
    {
        public static Appointment AsAppointment(this PatientAppointmentDto dto, int patientId)
        {
            var startTime = DateAndTimeUtil.SetTime(dto.AppointmentDate, dto.Start);
            var endTime = DateAndTimeUtil.SetTime(dto.AppointmentDate, dto.End);
            return new Appointment
            {
                PatientId = patientId,
                LocationId = dto.LocationId,
                Start = startTime,
                End = endTime,
                CreatedDate = DateTime.Now,
                CreatedBy = "5c4e4edb-5008-4723-b293-4ac67738de46",
                Deleted = false,
                AppointmentStatusId = (int)AppointmentStatusEnum.Booked,
                AppointmentNotes = $"{dto.TreatmentType} - {dto.AppointmentNotes?.ToString()}",
                ProgrammeId = dto.Programme
            };
        }

        public static PatientAppointmentDto AsPatientAppointmentDto(this Appointment appointment)
        {
            var ta = appointment.TherapistAppointments.FirstOrDefault();
            return new PatientAppointmentDto
            {
                AppointmentId = appointment.Id,
                Name = appointment.Patient.Name,
                Surname = appointment.Patient.Surname,
                LocationName = appointment.Location.LocationName,
                LocationId = appointment.LocationId,
                Start = appointment.Start.ToString(),
                End = appointment.End.ToString(),
                Gender = appointment.Patient.Gender,
                AppointmentDate = appointment.Start,
                DoB = appointment.Patient.Dob,
                AppointmentStatus = ((AppointmentStatusEnum)appointment.AppointmentStatusId).ToString(),
                IdNumber = appointment.Patient.Idnumber,
                MobileNumber = appointment.Patient.Mobile,
                PractitionerId = Convert.ToInt32(ta?.TherapistId),
                PractitionerName = $"{ta?.Therapist.FirstName} {ta?.Therapist.Surname}",
                PractitionerType = Convert.ToInt32(ta?.Therapist.TherapistTypeId),
                Treatment = ta?.Therapist.TherapistType.TherapistTypeName,
                TreatmentType = appointment.AppointmentNotes,
                EmailAddress = appointment.Patient.Email?.ToString()
            };
        }

        public static List<PatientAppointmentDto> AsListDto(this List<Appointment> appointments)
        {
            List<PatientAppointmentDto> listDto = new();
            foreach (Appointment item in appointments)
            {
                listDto.Add(item.AsPatientAppointmentDto());
            }
            return listDto;
        }

        public static TherapistAppointment AsPractitionerAppointment(this PatientAppointmentDto dto, int patientId, int appointmentId)
        {
            var startTime = DateAndTimeUtil.SetTime(dto.AppointmentDate, dto.Start);
            var endTime = DateAndTimeUtil.SetTime(dto.AppointmentDate, dto.End);
            return
                    new TherapistAppointment()
                    {
                        AppointmentId = appointmentId,
                        TherapistId = dto.PractitionerId,
                        Start = startTime,
                        End = endTime,
                        Duration = Convert.ToInt32((endTime - startTime).TotalMinutes)
                    };
        }

        public static NewAppointmentNotificationModel ToNotification(this PatientAppointmentDto dto, Location location, Appointment appointment, string baseurl)
        {
            return new NewAppointmentNotificationModel
            {
                PatientName = dto.Name,
                PatientSurname = dto.Surname,
                BranchName = location.LocationName,
                TreatmentSubType = dto.TreatmentType,
                TreatmentType = dto.Treatment,
                PractitionerType = dto.PractitionerType.ToString(),
                PractitionerName = dto.PractitionerName,
                AppointmentDate = dto.AppointmentDate.ToString("dd MMM yyyy"),
                AppointmentTime = dto.Start,
                Address = location.Address,
                Directions = location.AddressUrl,
                DetailsUrl = $"{baseurl}/view-appointment-details/{appointment.Id}/{appointment.PatientId}",
                CancelUrl = $"{baseurl}/cancel-patient-appointment/{appointment.Id}/{appointment.PatientId}"
            };
        }
        public static CancelAppointmentNotificationModel ToCancellationNotification(this Appointment appointment, Location location, string baseurl)
        {
            return new CancelAppointmentNotificationModel
            {
                PatientName = appointment.Patient.Name,
                PatientSurname = appointment.Patient.Surname,
                BranchName = location.LocationName,
                //PractitionerType = appointment.TherapistAppointments.ToString(),
                AppointmentDate = appointment.Start.ToString("dd MMM yyyy"),
                AppointmentTime = appointment.Start.ToString("HH:mm")
            };
        }

        public static DataAccess.Models.Patient ToPatient(this PatientAppointmentDto dto, Location location)
        {
            return new DataAccess.Models.Patient
            {
                Name = dto.Name,
                Surname = dto.Surname,
                LocationId = dto.LocationId,
                Gender = string.IsNullOrEmpty(dto.Gender)?string.Empty: dto.Gender,
                Dob = dto.DoB,
                IsDbc = false,
                Deleted = false,
                CreatedDate = DateTime.Now,
                CreatedBy = "5c4e4edb-5008-4723-b293-4ac67738de46",
                IsBlocked = false,
                Idnumber = dto.IdType.ToLower() == "id" ? dto.IdNumber : dto.PassportNumber,
                Mobile = dto.MobileNumber,
                Email = dto.EmailAddress,
                Title= string.Empty,
                MedicalAidId = dto.MedicalAidProviderId,
                MedicalAidNumber = dto.MedicalAidNumber,
                MedicalAidOptionName = dto.MedicalAidProviderName              

            };
        }

        public static AvailableSlotDto ToAvaiableSlot(this TimeRange slotTimeRange)
        {
            return new AvailableSlotDto
            {
                start = slotTimeRange.Start.ToString("HH:mm"),
                end = slotTimeRange.End.ToString("HH:mm")
            };
        }

        public static IEnumerable<AvailableSlotDto> ToAvaiableSlotList(this IEnumerable<TimeRange> slotTimeRange)
        {
            var list = new List<AvailableSlotDto>();
            slotTimeRange.ToList().ForEach(x =>
            {
                list.Add(x.ToAvaiableSlot());

            });
            return list;
        }

        public static IEnumerable<PractitionerTypesLocationDto> ToPractitionerTypesWithLocation(this IEnumerable<PractitionerTypeLocation> types)
        {
            var list = new List<PractitionerTypesLocationDto>();
            types.ToList().ForEach(x =>
            {
                var item = new PractitionerTypesLocationDto();
                item.Id = x.Id;
                item.TherapistTypeName = x.TherapistType.TherapistTypeName;
                item.TherapistTypeId = x.TherapistTypeId;
                item.IsActive = x.TherapistType.IsActive;
                item.IsPortalVisible = x.TherapistType.IsPortalVisible;
                item.MaxConcurrantAppointments = x.TherapistType.MaxConcurrantAppointments;
                item.ShortName = x.TherapistType.ShortName;
                item.LocationName = x.Location?.LocationName;
                item.LocationId = x.LocationId;
                list.Add(item);

            });
            return list;
        }
    }
}