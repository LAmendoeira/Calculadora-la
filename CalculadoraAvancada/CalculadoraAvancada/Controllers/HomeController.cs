using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalculadoraAvancada.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Visor = 0;
            //Inicializar variaveis
            Session["primeiroOperador"] = true;
            Session["limpaVisor"] = true;
            ViewBag.Op1 = "0";
            ViewBag.Op2 = "0";
            ViewBag.Opr = "";
            return View();
        }

        // POST: Home
        [HttpPost]
        public ActionResult Index(string bt, string visor)
        {

            // identificar o valor da variavel 'bt'
            switch (bt)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "0":
                    if (visor.Equals("0") || (bool)Session["limpaVisor"])
                    {
                        visor = bt;
                        
                    } else
                    {
                        visor += bt;
                        
                    }
                    Session["limpaVisor"] = false;
                    break;


                case "+/-":
                    visor = Convert.ToDouble(visor) * -1 + "";
                    break;

                case ",":
                    if(!visor.Contains(","))
                    {
                        visor += bt;
                    }
                    break;

                case "+":
                case "-":
                case "x":
                case ":":
                case "=":
                    if((bool)Session["primeiroOperador"] && !(bt.Equals("=")))
                    {
                        //Primeira vez que se carrega no operador
                        Session["operando"] = visor;
                        Session["operadorAnterior"] = bt;
                        Session["primeiroOperador"] = false;
                        visor = "0";
                        break;
                    }
                    else
                    {
                        double operando1 = Convert.ToDouble((string)Session["operando"]);
                        double operando2 = Convert.ToDouble(visor);
                        switch ((string)Session["operadorAnterior"])
                        {
                            case "+":
                                visor = operando1 + operando2 + "";
                                break;
                            case "-":
                                visor = operando1 - operando2 + "";
                                break;
                            case "x":
                                visor = operando1 * operando2 + "";
                                break;
                            case ":":
                                if(operando2 == 0)
                                {
                                    visor = "ERRO";
                                    Session["operando"] = "";
                                }
                                else
                                {
                                    visor = operando1 / operando2 + "";
                                }
                                break;
                        }
                        if (!bt.Equals("="))
                        {
                            Session["operadorAnterior"] = bt;
                        }
                        
                        Session["operando"] = visor;
                        Session["limpaVisor"] = true;
                    }
                    break;
                //case "+":
                //    if (op1.Equals("0"))
                //    {
                //        ViewBag.Op1 = visor;
                //        visor = "0";
                //        ViewBag.Opr = "+";
                //        break;
                //    } else
                //    {
                //        break;
                //    }
                //case "-":
                //    if (op1.Equals("0"))
                //    {
                //        ViewBag.Op1 = visor;
                //        visor = "0";
                //        ViewBag.Opr = "-";
                //        break;
                //    }
                //    else
                //    {
                //        break;
                //    }
                //case "x":
                //    if (op1.Equals("0"))
                //    {
                //        ViewBag.Op1 = visor;
                //        visor = "0";
                //        ViewBag.Opr = "x";
                //        break;
                //    }
                //    else
                //    {
                //        break;
                //    }
                //case ":":
                //    if (op1.Equals("0"))
                //    {
                //        ViewBag.Op1 = visor;
                //        visor = "0";
                //        ViewBag.Opr = ":";
                //        break;
                //    }
                //    else
                //    {
                //        break;
                //    }
                case "C":
                    //var index = visor.Count() - 1;
                    //visor = visor.Remove(index);

                    //Ou apaga mesmo tudo?
                    visor = "0";
                    break;
            } //END switch (bt)

            ViewBag.Visor = visor;
            return View();
        }

        //public ActionResult Index(string bt, string visor, string op1, string op2, string opr)
        //{
        //    ViewBag.Op1 = op1;
        //    ViewBag.Op2 = op2;
        //    ViewBag.Opr = opr;

        //    // identificar o valor da variavel 'bt'
        //    switch (bt)
        //    {
        //        case "1":
        //        case "2":
        //        case "3":
        //        case "4":
        //        case "5":
        //        case "6":
        //        case "7":
        //        case "8":
        //        case "9":
        //            if (visor.Equals("0"))
        //            {
        //                visor = bt;
        //                break;
        //            }
        //            else
        //            {
        //                visor += bt;
        //                break;
        //            }
        //        case "+":
        //            if (op1.Equals("0"))
        //            {
        //                ViewBag.Op1 = visor;
        //                visor = "0";
        //                ViewBag.Opr = "+";
        //                break;
        //            }
        //            else
        //            {
        //                break;
        //            }
        //        case "-":
        //            if (op1.Equals("0"))
        //            {
        //                ViewBag.Op1 = visor;
        //                visor = "0";
        //                ViewBag.Opr = "-";
        //                break;
        //            }
        //            else
        //            {
        //                break;
        //            }
        //        case "x":
        //            if (op1.Equals("0"))
        //            {
        //                ViewBag.Op1 = visor;
        //                visor = "0";
        //                ViewBag.Opr = "x";
        //                break;
        //            }
        //            else
        //            {
        //                break;
        //            }
        //        case ":":
        //            if (op1.Equals("0"))
        //            {
        //                ViewBag.Op1 = visor;
        //                visor = "0";
        //                ViewBag.Opr = ":";
        //                break;
        //            }
        //            else
        //            {
        //                break;
        //            }
        //        case "C":
        //            //var index = visor.Count() - 1;
        //            //visor = visor.Remove(index);

        //            //Ou apaga mesmo tudo?
        //            visor = "0";
        //            break;
        //        case "=":
        //            op2 = visor;
        //            if (!(op1.Equals("0") && op2.Equals("0")))
        //            {
        //                float auxOp1;
        //                float auxOp2;
        //                float result;
        //                if (float.TryParse(op1, out auxOp1) && float.TryParse(op2, out auxOp2))
        //                {
        //                    switch (opr)
        //                    {
        //                        case "+":
        //                            result = auxOp1 + auxOp2;
        //                            visor = result.ToString();
        //                            ViewBag.Op2 = "0";
        //                            ViewBag.Op1 = "0";
        //                            ViewBag.Opr = "";
        //                            break;
        //                        case "-":
        //                            result = auxOp1 - auxOp2;
        //                            visor = result.ToString();
        //                            ViewBag.Op2 = "0";
        //                            ViewBag.Op1 = "0";
        //                            ViewBag.Opr = "";
        //                            break;
        //                        case "x":
        //                            result = auxOp1 * auxOp2;
        //                            visor = result.ToString();
        //                            ViewBag.Op2 = "0";
        //                            ViewBag.Op1 = "0";
        //                            ViewBag.Opr = "";
        //                            break;
        //                        case ":":
        //                            result = auxOp1 / auxOp2;
        //                            visor = result.ToString();
        //                            ViewBag.Op2 = "0";
        //                            ViewBag.Op1 = "0";
        //                            ViewBag.Opr = "";
        //                            break;
        //                    }
        //                }

        //            }
        //            break;
        //    }

        //    ViewBag.Visor = visor;
        //    return View();
        //}
    }
}