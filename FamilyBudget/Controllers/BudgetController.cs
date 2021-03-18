using FamiliBudget.Serv;
using FamiliBudget.Serv.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyBudget.Controllers
{
    [Authorize]
    public class BudgetController : Controller
    {
        private IDBService DBService;
        public BudgetController(IDBService service)
		{
            DBService = service;
        }
        public ActionResult AllUserBudget(int id)
        {
            var user = DBService.FindUserById(id);
            return View(user);
        }

        public ActionResult CurrentUserBudget()
        {
            var user = DBService.FindUser(t => t.Login == User.Identity.Name);
            var budgets = DBService.GetBudgetsByUserId(user.ID);
            return View("CurrentUserBudget", budgets);
        }

        public ActionResult CreateBudget()
		{
            var user = DBService.FindUser(t=> t.Login==User.Identity.Name);
            var budget = new Budget() { UserID=user.ID };
            DBService.CreateBudget(budget);
            return View("UserBudget", budget);

        }
        // GET: Budget
        public ActionResult UserBudget(int id)
        {
            var model = DBService.FindBudgetByID(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Save(Budget budget)
		{
            budget.User = DBService.FindUser(t => t.ID == budget.UserID.Value);
            DBService.SaveBudget(budget);
            var user = DBService.FindUserById(budget.UserID.Value);
            user.Budgets.Add(budget);
            DBService.SaveUser(user);
            return View("UserBudget",budget);
		}
        [HttpGet]
        public HtmlString GetPositionBlock(int index)
		{
			return new HtmlString(
				string.Format(@"<div class=""position_{0}"">
							<div class=""row mt-2"">
								<div class=""col-md-1 themed-grid-col"" >
									<input class=""form-control"" type=""text"" name=""Positions[{0}].Name"" value="""" />
								</div>
								<div class=""col-md-2 themed-grid-col"" >
									<input class=""form-control"" type=""text""
										   name=""Positions[{0}].CountInDat"" value="""" onchange=""changeAmount({0})"" />
								</div>
								<div class=""col-md-3  themed-grid-col"" >
									<input type=""hidden"" name=""Positions[{0}].DayInWeeks"" value =""[]"" />
									<input type=""hidden"" name=""Positions[{0}].DayInWeek"" value="""" />
									<div class=""btn-group-toggle"" data-toggle=""buttons"" >
										<label class=""btn btn-light"" id=""DayInWeek_{0}_0"" >
											<input type=""checkbox"" name=""DayInWeek_{0}"" value =""0""
												   onchange=""changeAmount({0})"" /> Пн
										</label>
										<label class=""btn btn-light"" id=""DayInWeek_{0}_1"" >
											<input type=""checkbox"" name=""DayInWeek_{0}"" value =""1""
												   onchange=""changeAmount({0})"" /> Вт
										</label>
										<label class=""btn btn-light"" id=""DayInWeek_{0}_2"" >
											<input type=""checkbox"" name =""DayInWeek_{0}"" value =""2""
												   onchange=""changeAmount({0})"" /> Ср
										</label>
										<label class=""btn btn-light"" id =""DayInWeek_{0}_3"" >
											<input type=""checkbox"" name=""DayInWeek_{0}"" value=""3""
												   onchange=""changeAmount({0})"" /> Чт
										</label>
										<label class=""btn btn-light"" id=""DayInWeek_{0}_4"" >
											<input type=""checkbox"" name=""DayInWeek_{0}"" value =""4""
												   onchange=""changeAmount({0})""/> Пт
										</label>
										<label class=""btn btn-light"" id=""DayInWeek_{0}_5"">
											<input type=""checkbox"" name=""DayInWeek_{0}"" value=""5""
												   onchange=""changeAmount({0})"" /> Сб
										</label>
										<label class=""btn btn-light"" id=""DayInWeek_{0}_6"">
											<input type=""checkbox"" name=""DayInWeek_{0}"" value=""6""
												   onchange=""changeAmount({0})"" /> Вс
										</label>
									</div>
								</div>
								<div class=""col-md-2  themed-grid-col"" >
									<div class=""btn-group-toggle"" data-toggle=""buttons"" >
										<input type=""hidden"" name=""Positions[{0}].WeekInMonths"" value=""[]"" />
										<input type=""hidden"" name=""Positions[{0}].WeekInMonth"" value="""" />
										<label class=""btn btn-light"" id=""WeekInMonth_{0}_0"">
											<input type=""checkbox"" name=""WeekInMonth_{0}"" value =""1""
												   onchange=""changeAmount({0})"" /> 1
										</label>
										<label class=""btn btn-light"" id =""WeekInMonth_{0}_1"">
											<input type=""checkbox"" name=""WeekInMonth_{0}"" value=""2""
												   onchange=""changeAmount({0})"" /> 2
										</label>
										<label class=""btn btn-light"" id=""WeekInMonth_{0}_2"">
											<input type=""checkbox"" name=""WeekInMonth_{0}"" value=""3""
												   onchange=""changeAmount({0})"" /> 3
										</label>
										<label class=""btn btn-light"" id=""WeekInMonth_{0}_3"">
											<input type=""checkbox"" name=""WeekInMonth_{0}"" value=""4""
												   onchange=""changeAmount({0})"" /> 4
										</label>
									</div>
								</div>
								<div class=""col-md-2  themed-grid-col"">
									<input class=""form-control"" type=""text"" name=""Positions[{0}].MonthAmount"" value="""" onchange=""changeAmount({0})"" />
								</div>
								<div class=""col-md-1  themed-grid-col"">
									<input class=""form-control"" type=""hidden"" name=""Positions[{0}].Amount"" value=""0"" />
									<span class=""amount_{0}"">0</span>
								</div>
								<div class=""col-md-1 themed-grid-col"">
									<span class=""btn btn-danger"" onclick=""deletePosition({0})"">удалить</span>
								</div>
							</div>
						</div>", index));
        }
    }
}