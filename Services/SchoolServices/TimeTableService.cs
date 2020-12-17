using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using YukonTest.Domain;
using YukonTest.Dtos.TimeTableHandle;
using YukonTest.Models;

namespace YukonTest.Services.SchoolServices
{
    public class TimeTableService : ITimeTableService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public TimeTableService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetTeachersDto>>> GetAllTeachers()
        {
            ServiceResponse<List<GetTeachersDto>> serviceResponse = new ServiceResponse<List<GetTeachersDto>>();
            try
            {
                serviceResponse.Data = (_context.Teachers.Select(a => _mapper.Map<GetTeachersDto>(a))).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTeachersDto>> GetTeacherById(int id)
        {
            ServiceResponse<GetTeachersDto> serviceResponse = new ServiceResponse<GetTeachersDto>();
            try
            {
                serviceResponse.Data = _mapper.Map<GetTeachersDto>(_context.Teachers.FirstOrDefault(a => a.TeacherID == id));
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTeachersDto>> UpdateTeacher(UpdateTeacherDto req)
        {
            ServiceResponse<GetTeachersDto> serviceResaponse = new ServiceResponse<GetTeachersDto>();
            try
            {
                Teacher teacher = _context.Teachers.FirstOrDefault(a => a.TeacherID == req.TeacherID);
                teacher.Leave = req.Leave;
                _context.SaveChanges();
                serviceResaponse.Data = _mapper.Map<GetTeachersDto>(teacher);
            }
            catch (Exception ex)
            {
                serviceResaponse.Success = false;
                serviceResaponse.Message = ex.Message;
            }
            return serviceResaponse;
        }


        public async Task<ServiceResponse<List<DailyTimeTableDto>>> GetTodayTimeTable(DateTime todayDate, string user, int teacherId)
        {
            ServiceResponse<List<DailyTimeTableDto>> serviceResponse = new ServiceResponse<List<DailyTimeTableDto>>();
            try
            {
                var dayId = _context.Days.SingleOrDefault(a => a.DayName == todayDate).DayID;

                List<DailyTimeTableDto> dtt = new List<DailyTimeTableDto>();

                if (user == "student")
                {
                    var pbd = _context.PeriodByDays.Where(a => a.DayID == dayId).ToList();
                    foreach (var item in pbd)
                    {
                        DailyTimeTableDto obj = new DailyTimeTableDto();
                        obj.PeriodName = _context.Periods.SingleOrDefault(c => c.PeriodID == item.PeriodID).PeriodName;
                        obj.SubjectName = _context.Subjects.SingleOrDefault(c => c.SubjectId == item.SubjectID).SubjectName;
                        obj.TeacherName = _context.Teachers.SingleOrDefault(c => c.TeacherID == item.TeacherID).Name;
                        dtt.Add(obj);
                    }
                }
                else if (user == "teacher")
                {
                    var pbd = _context.PeriodByDays.Where(a => a.TeacherID == teacherId && a.DayID == dayId).ToList();
                    foreach (var item in pbd)
                    {
                        DailyTimeTableDto obj = new DailyTimeTableDto();
                        obj.PeriodName = _context.Periods.SingleOrDefault(c => c.PeriodID == item.PeriodID).PeriodName;
                        obj.SubjectName = _context.Subjects.SingleOrDefault(c => c.SubjectId == item.SubjectID).SubjectName;
                        dtt.Add(obj);
                    }
                }
                else
                {
                    dtt = null;
                }
                serviceResponse.Data = dtt;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<UpdateLeaveDto>> UpdateLeave(UpdateLeaveDto req)
        {
            ServiceResponse<UpdateLeaveDto> serviceResaponse = new ServiceResponse<UpdateLeaveDto>();
            try
            {
                Teacher teacher = _context.Teachers.FirstOrDefault(a => a.TeacherID == req.TeacherID);
                teacher.Leave = req.Leave;

                Random rnd = new Random();
                Absent absent = new Absent
                {
                    AbsentID = rnd.Next(),
                    AbsentDay = Convert.ToDateTime(req.AbsentDate),
                    TeacherID = req.TeacherID
                };
                _context.Absents.Add(absent);                
                _context.SaveChanges();
                serviceResaponse.Data = _mapper.Map<UpdateLeaveDto>(teacher);
            }
            catch (Exception ex)
            {
                serviceResaponse.Success = false;
                serviceResaponse.Message = ex.Message;
            }
            return serviceResaponse;
        }
    }
}