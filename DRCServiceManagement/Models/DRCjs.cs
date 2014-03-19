using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Data;
using System.Web.UI.WebControls;

namespace DRCServiceManagement.Models
{
    public class DRCjs
    {
        DRCCORPDBDataContext db = new DRCCORPDBDataContext();
        DRCClientDBDataContext db2 = new DRCClientDBDataContext();
        DRCRepository DRCrepos = new DRCRepository();
        InnerElements IE = new InnerElements();
        JavaFunctions JF = new JavaFunctions();

        public string autocombo()
        {
           
         string js= @"(function($) {
		$.widget('ui.combobox', {
			_create: function() {
				var self = this;
				var select = this.element.hide();
				var input = $('<input title=CTRLClickToSelectAllText>')
					.insertAfter(select)
					.autocomplete({
						source: function(request, response) {
							var matcher = new RegExp(request.term, 'i');
							response(select.children('option').map(function() {
								var text = $(this).text();

								if (this.value && (!request.term || matcher.test(text)))
									return {
										id: this.value,
										label: text.replace(new RegExp('(?![^&;]+;)(?!<[^<>]*)(' + $.ui.autocomplete.escapeRegex(request.term) + ')(?![^<>]*>)(?![^&;]+;)', 'gi'), '<strong>$1</strong>'),
										value: text
									}
							}));
						},
						delay: 0,
						change: function(event, ui) {
							if (!ui.item) {
								// remove invalid value, as it didn't match anything
								$(this).val('');
								return false;
							}
							select.val(ui.item.id);

							self._trigger('selected', event, {
								item: select.find('[value=' + ui.item.id + ']')
							});
						
						},
						minLength: 0,
                        select: function(event,ui){getcustomer(ui.item.id);
                $('#CustmenuContainer').show();
                PCustID=ui.item.id;
                $.post('/DRCCustomer/getContacts', {CustID: PCustID});
                $(CustRecPayment).show();
                if(PCustID!=CustomerJobs)
                        {
                        $(JobTableName).remove();
                        $(divJobLogs).empty();
                        CustomerJobs=PCustID;
                 //       $.post('/DRCCustomer/getJobRequests', { CustID:PCustID ,Complete:false,Incomplete:true,All:false});
                        }
 }
                        
					})
					.addClass('ui-widget ui-widget-content ui-corner-left');

$('<button>&nbsp;</button>')
				.attr('tabIndex', -1)
				.attr('title', 'Show All Items')
				.insertAfter(input)
				.button({
					icons: { 
						primary: 'ui-icon-triangle-1-s'
					},
					text: false
				}).removeClass('ui-corner-all')
				.addClass('ui-corner-right ui-button-icon')
				.click(function() {
					// close if already visible
					if (input.autocomplete('widget').is(':visible')) {
						input.autocomplete('close');
						return;
					}
					// pass empty string as value to search for, displaying all results
					input.autocomplete('search', '');
					input.focus();

				});
			}
		});

	})(jQuery);

		
	$(function() {
		$('#combobox').combobox();
		$('#toggle').click(function() {
			$('#combobox').toggle();
		});
	});";


            return js;
        }
        #region**********************************autocombo******************************************************
        public string autocomboElementA1()
        {
            string js = @"(function($) {
		$.widget('ui.";
            return js;
        }
        
        public string autocomboElementA4()
        {
            string js = @"').";
            return js;
        }
        public string autocomboElementA5()
        {
            string js = @"();
		$('#toggle').click(function() {
			$('#";
            return js;
        }
        
        public string autocomboElementA3()
        {
            string js = @"(ui.item);}
                        
					})
					.addClass('ui-widget ui-widget-content ui-corner-left');

$('<button>&nbsp;</button>')
				.attr('tabIndex', -1)
				.attr('title', 'Show All Items')
				.insertAfter(input)
				.button({
					icons: { 
						primary: 'ui-icon-triangle-1-s'
					},
					text: false
				}).removeClass('ui-corner-all')
				.addClass('ui-corner-right ui-button-icon')
				.click(function() {
					// close if already visible
					if (input.autocomplete('widget').is(':visible')) {
						input.autocomplete('close');
						return;
					}
					// pass empty string as value to search for, displaying all results
					input.autocomplete('search', '');
					input.focus();

				});
			}
		});

	})(jQuery);

		
	$(function() {
		$('#";
            return js;
        }
        public string autocomboSelectA2()
        {
            string js = @"', {
			_create: function() {
				var self = this;
				var select = this.element.hide();
				var input = $('<input>')
					.insertAfter(select)
					.autocomplete({
						source: function(request, response) {
							var matcher = new RegExp(request.term, 'i');
							response(select.children('option').map(function() {
								var text = $(this).text();

								if (this.value && (!request.term || matcher.test(text)))
									return {
										id: this.value,
										label: text.replace(new RegExp('(?![^&;]+;)(?!<[^<>]*)(' + $.ui.autocomplete.escapeRegex(request.term) + ')(?![^<>]*>)(?![^&;]+;)', 'gi'), '<strong>$1</strong>'),
										value: text
									}
							}));
						},
						delay: 0,
						change: function(event, ui) {
							if (!ui.item) {
								// remove invalid value, as it didn't match anything
								$(this).val('');
								return false;
							}
							select.val(ui.item.id);

							self._trigger('selected', event, {
								item: select.find('[value=' + ui.item.id + ']')
							});
						
						},
						minLength: 0,
                        select: function(event,ui){";
            return js;
        }

        public string autocomboEnd()
        {
            string js = @"').toggle();
		});
	});";
            return js;
        }

        #endregion


        public string makeselection(string id, string item, string value)
        {
            string js = @"$('#" + id + @"').append('<option value=\'" + value + @"\'>" + item + @"</option>');";
            return js;
        }
        public string makeddlInputPair(string lblclass,string ddlclass,string tbclass,string type, string div, string selected, string name, string filter,string lbl, string title, int autotype, int subsize)//autotype 0 for first characters, 1 for characters in any position
        {
                DRCMethods DRCM = new DRCMethods();
                string tbval = ">";
                string thelabel = @"<label id=lblddl" + name + @" class="+lblclass+@">" + lbl + @"</label>";
                string Lists = @" $(divLists).append('<select class=SUB" + ddlclass + @" id=sddl" + name + @"></select>'); ";
                string ddl = @"<select class=" + ddlclass + @" id=ddl" + name + @">";
                ddl = ddl + @"<option value=0>NEW ENTRY</option>";
                string tb = @"<input type=text class="+tbclass+@" id=tb" + name + @" ";

                #region Selection List Types$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
                switch (type)
            {
                case "STKBIN":
                    List<DRC_ItemBin> Bin = DRCrepos.getItemBins(Convert.ToInt32(filter));
                    foreach (DRC_ItemBin B in Bin)
                    {
                        ddl=ddl + @"<option value=" + B.BinID + @">" + B.Name + @"</option>";
                    }
                    if(Bin.Count>0) tbval = @"value="+ Bin[0].Name + tbval;
                    break;
                case "STKBUILDING":
                    List<DRC_ItemBuilding> Bldg = DRCrepos.getItemBuildings(Convert.ToInt32(filter));
                    foreach (DRC_ItemBuilding B in Bldg)
                    {
                        ddl=ddl + @"<option value=" + B.BuildingID + @">" + B.Name + @"</option>";
                    }
                    if (Bldg.Count > 0) tbval = @"value=" + Bldg[0].Name + tbval;
                    break;
                case "STKROOM":
                    List<DRC_ItemRoom> Room = DRCrepos.getItemRooms(Convert.ToInt32(filter));
                    foreach (DRC_ItemRoom R in Room)
                    {
                        ddl=ddl + @"<option value=" + R.RoomID + @">" + R.Name + @"</option>";
                    }
                    if (Room.Count > 0) tbval = @"value=" + Room[0].Name + tbval;
                    break;
                case "ACCOUNTS":
                    List<Account> al = DRCrepos.AccountList(Convert.ToInt32(filter));

                    foreach (var a in al)
                    {
                        ddl = ddl + @"<option value=" + a.AccountID + @">" + DRCM.fixstring(a.Name) + @"</option>";
                    }
                    if (al.Count > 0) tbval = @"value=" + al[0].Name + tbval;
                    break;

                    case "STATELIST":
                    List<DRC_StateProvenceList> States = DRCrepos.getStates();
                    foreach (DRC_StateProvenceList ST in States)
                    {
                        ddl = ddl + @"<option value=" + ST.StateID + @">" + DRCM.fixstring(ST.StateName) + @"</option>";
                        
                    }
                    if (States.Count > 0) tbval = @"value=" + DRCM.fixstring(States[0].StateName) + tbval;
                    break;
                    case "CITYLIST":
                    List<DRC_CityList> Cities = DRCrepos.getCities();
                    foreach (DRC_CityList CT in Cities)
                    {
                        ddl = ddl + @"<option value=" + CT.CityID + @">" + DRCM.fixstring(CT.Name) + @"</option>";

                    }
                    if (Cities.Count > 0) tbval = @"value=" + DRCM.fixstring(Cities[0].Name) + tbval;
                    break;
                    case "COUNTRYLIST":
                    List<DRC_CountryList> Country = DRCrepos.getCountries();
                    foreach (DRC_CountryList CO in Country)
                    {
                        ddl = ddl + @"<option value=" + CO.CountryID + @">" + DRCM.fixstring(CO.Name) + @"</option>";
                        
                    }
                    if (Country.Count > 0) tbval = @"value=" + DRCM.fixstring(Country[0].Name) + tbval;
                    break;
                    case "TERMSLIST":
                    List<DRC_Term> Terms = DRCrepos.getTerms();
                    foreach (DRC_Term T in Terms)
                    {
                        ddl = ddl + @"<option value=" + T.TermsID + @">" + DRCM.fixstring(T.TermsDescription) + @"</option>";

                    }
                    if (Terms.Count > 0) tbval = @"value=" + DRCM.fixstring(Terms[0].TermsDescription) + tbval;
                    break;
                    case "TAXLOCLIST":
                    List<DRC_TaxCode> TaxCodes = DRCrepos.getTaxCodes();
                    foreach (DRC_TaxCode TC in TaxCodes)
                    {
                        DRCMethods DM = new DRCMethods();
                        double taxpercent = Math.Round(DM.makeTaxInfo(Convert.ToInt32(TC.TaxCodeID)).TaxPercent,2);
                        ddl = ddl + @"<option value=" + TC.TaxCodeID+ @">" + TC.Name+@":"+DRCM.fixstring(TC.Description) +@"-"+taxpercent+@"%"+ @"</option>";

                    }
                    if (TaxCodes.Count > 0) tbval = @"value=" + DRCM.fixstring(TaxCodes[0].Description) + tbval;
                    break;
                    case "ItemType":
                    List<DRC_PNCode> PNtype = DRCrepos.getPNCodes();
                    foreach (DRC_PNCode PN in PNtype)
                    {
                        ddl = ddl + @"<option value=" + PN.Code + @">" + DRCM.fixstring(PN.ProductType) + @"</option>";
                    }
                    if (PNtype.Count > 0) tbval = @"value=" + DRCM.fixstring(PNtype[0].ProductType) + tbval;
                    break;
                    case "ItemMan":
                    List<DRC_ManCode> Man = DRCrepos.getManCodes();
                    foreach (DRC_ManCode M in Man)
                    {
                        ddl = ddl + @"<option value=" + M.Code + @">" + DRCM.fixstring(M.Manufacturer) + @"</option>";
                    }
                    if (Man.Count > 0) tbval = @"value=" + DRCM.fixstring(Man[0].Manufacturer) + tbval;
                    break;
                    case "ItemDescript":
                        
                        if (filter=="0:0")
                        {
                            filter = DRCrepos.getfirstItemTypeManIDSet();
                        }
                        int Itype=Convert.ToInt32(filter.Substring(0,(filter.LastIndexOf(':'))));
                        int IMan=Convert.ToInt32(filter.Substring((filter.LastIndexOf(':')+1)));
                        
                        List<DRC_ItemInvAccountTable> Items = DRCrepos.getItemsbyTypeAndMan(Itype, IMan);
                        List<Account> Iacct=new List<Account>();
                        foreach (DRC_ItemInvAccountTable item in Items)
	                {
                            Iacct.Add(DRCrepos.getAccount(Convert.ToInt32(item.AccountID)));
	                }
                    foreach (Account A  in Iacct)
                    {
                        ddl = ddl + @"<option value=" + A.AccountID + @">" + DRCM.fixstring(A.Name) + @"</option>";
                    }
                    if (Iacct.Count > 0) tbval = @"value=" + DRCM.fixstring(Iacct[0].Name) + tbval;
                    break;

                    case "ItemName":

                    if (filter == "0:0")
                    {
                        filter = DRCrepos.getfirstItemTypeManIDSet();
                    }
                    int Ittype = Convert.ToInt32(filter.Substring(0, (filter.LastIndexOf(':'))));
                    int ItMan = Convert.ToInt32(filter.Substring((filter.LastIndexOf(':') + 1)));

                    List<DRC_ItemInvAccountTable> IItems = DRCrepos.getItemsbyTypeAndMan(Ittype, ItMan);
                    List<Account> IIacct = new List<Account>();
                    foreach (DRC_ItemInvAccountTable item in IItems)
                    {
                        IIacct.Add(DRCrepos.getAccount(Convert.ToInt32(item.AccountID)));
                    }
                    foreach (Account A in IIacct)
                    {
                        ddl = ddl + @"<option value=" + A.AccountID + @">" + DRCM.fixstring(A.AlphaPart) + @"</option>";
                    }
                    if (IIacct.Count > 0) tbval = @"value=" + DRCM.fixstring(IIacct[0].Name) + tbval;
                    break;

                    case "CONTACT"://filter is for contact account id
                    List<DRC_Contact> contacts = new List<DRC_Contact>();
                    int acctid = Convert.ToInt32(filter);
                    var C = from c in db.DRC_Contacts where c.AccountID == acctid select c;
                    if (C.Count() > 0)
                    {
                        
                        foreach (DRC_Contact con in C)
                        {
                            string pn = "";
                            if (con.MobilePhone1 != null && con.MobilePhone1.Length > 6)
                            {
                                pn = @"(" + con.MobilePhone1.Substring(0, 3) + @")" + con.MobilePhone1.Substring(4, 3) + @"-" + con.MobilePhone1.Substring(5, 4);
                            }
                            string ov = con.ContactID + @">" + con.FirstName + @" " + con.LastName + @" : " + pn;
                            if (selected == con.ContactID.ToString()) { selected = ov; }
                            ddl = ddl + @"<option value=" +ov  + @"</option>";
                        }

                    }
                    else
                    {
                        selected = "NEW ENTRY";
                    }
                    break;

                    case "JOBCODE"://Filter for job code type
                    List<JobCode> codes = new List<JobCode>();
                    int codetype = Convert.ToInt32(filter);
                    var JC = from c in db.JobCodes where c.CodeType == codetype select c;
                    foreach (JobCode code in JC)
                    {
                        ddl = ddl + @"<option value=" + code.CodeID + @">" + code.Code + @"</option>";
                    }
                    break;
            }
                #endregion
                tb = tb + tbval;
            ddl = ddl + @"</select>";

            string F0 = @" var selval" + name + @"=0; var downarrowpress=false;" ;
            if (selected == "") F0 = F0 + @" selval" + name + @"=document.getElementById('ddl" + name + @"').options[1].value;
            document.getElementById('ddl" + name + @"').options[1].selected=true;
            $(tb" + name + @").val(document.getElementById('ddl" + name + @"').options[1].text);
            ";
            else
            {

                F0 = F0 + @"  $(tb" + name + @").val('" + selected + @"');
                            for (var i=0;i<document.getElementById('ddl" + name + @"').length;i++)
                            {
                                if(document.getElementById('ddl" + name + @"').options[i].text=='" + selected + @"')
                                    {
                                       selval" + name + @"= document.getElementById('ddl" + name + @"').options[i].value;
                                       document.getElementById('ddl" + name + @"').options[i].selected=true;
                                       
                                    }
                            } 

";
            }


            string F1 = @"var l" + name + @"= 0; var idx" + name + @"=0; $(sddl" + name + @").hide(); var sidx"+name+@"=0; var  ddlval"+name+@"=0;
              $(tb" + name + @").keyup(function(event)
                {
                    l" + name + @"=$(tb" + name + @").val().length;
               

                    try //error happens when tabbing but does not affect intended proccess so put in try group
                    {
                    
                        if(l" + name + @">0)
                            {
                                $(ddl" + name + @").hide();
                                $(sddl" + name + @").empty();
                                $(sddl" + name + @").append('<option value=0>NEW ENTRY</option>');
                                for (var i=1;i<document.getElementById('ddl" + name + @"').length;i++)
                                    {
                                        ddlval" + name + @"=document.getElementById('ddl" + name + @"').options[i].value;
                                        if($(tb" + name + @").val()==document.getElementById('ddl" + name + @"').options[i].text)
                                            {   
                                                document.getElementById('ddl" + name + @"').options[i].selected=true;
                                                selval" + name + @"= document.getElementById('ddl" + name + @"').options[i].value;
                                            }
                                        else{
                                                document.getElementById('ddl" + name + @"').selectedIndex=-1;
                                                selval" + name + @"=0;
                                            }
                        
";
                    
            switch (autotype)
	{
                case 0:
            F1 = F1 + @"
                                        
                            
                                        if(document.getElementById('ddl" + name + @"').options[i].text.substr(0,l" + name + @").toUpperCase()==$(tb" + name + @").val().toUpperCase())
                                            {
                                    
                                    
                                                $(sddl" + name + @").append('<option value='+ddlval" + name + @"+'>'+document.getElementById('ddl" + name + @"').options[i].text+'</option>');
                                                sidx" +name+@"++;
                                            }

                                        
";  
                    

                    break;
                case 1:
                    
                    F1 = F1 + @"
                                        if(document.getElementById('ddl" + name + @"').options[i].text.toUpperCase().lastIndexOf($(tb" + name + @").val().toUpperCase())>-1)
                                            {
                                    
                                                $(sddl" + name + @").show();
                                                $(sddl" + name + @").append('<option value='+ddlval"+name+@"+'>'+document.getElementById('ddl" + name + @"').options[i].text+'</option>');
                                                sidx" + name + @"++;
                                            
}";    

                    break;

		default:
 break;
	}
                                
                              
                  F1=F1+ @"
                                        }//This is the end of the for loop
                               var sddlLENGTH=document.getElementById('sddl" + name + @"').length;
                                document.getElementById('sddl" + name + @"').selectedIndex=0;
                                if (sddlLENGTH>0)
                                            {
                                                $(ddl" + name + @").hide();
                                                $(sddl" + name + @").show();
                                                if(event.keyCode==40)
                                                {(sddl" + name + @").focus(); downarrowpress=true;}
                                                else
                                                {downarrowpress=false;}
                                                if(sddlLENGTH<" + subsize + @")
                                                    {
                                                        $(sddl" + name + @").attr('size',sddlLENGTH);
                                                    }
                                                    else
                                                    {
                                                        $(sddl" + name + @").attr('size','" + subsize + @"');
                                                    }
                                            }
                                        else
                                            {
                                                $(ddl" + name + @").show();
                                                $(sddl" + name + @").hide();
                                                
                                            }
                                
                            }
                        else
                            {
                            
                                $(ddl" + name + @").show();
                                $(sddl" + name + @").hide();
                            }
                    }
                 catch(err)
                    {
                    }   
            




});";
                  string F2 = @"  $(ddl" + name + @").change(function(event){$(tb" + name + @").val(document.getElementById('ddl" + name + @"').options[document.getElementById('ddl" + name + @"').selectedIndex].text); selval" + name + @"=document.getElementById('ddl" + name + @"').options[document.getElementById('ddl" + name + @"').selectedIndex].value; $(ddl"+name+@").hide(); 
//showDetailsButton('" + name + @"');
});";
                  string F3 = @" $(sddl" + name + @").change(function(event){$(tb" + name + @").val(document.getElementById('sddl" + name + @"').options[document.getElementById('sddl" + name + @"').selectedIndex].text); selval" + name + @"=document.getElementById('sddl" + name + @"').options[document.getElementById('sddl" + name + @"').selectedIndex].value; 

//showDetailsButton('" + name + @"');  
$(sddl" + name + @").hide();}); ";
            string F4 = @" function " + name + @"selmouseover(selectedidx)
                          {
                            
                            alert(selectedidx);
                          }
                        function " + name + @"selmouseout(selectedidx)
                          {
                            alert(selectedidx);
                          }


            ";
            string F5 = @" $(tb" + name + @").blur(function(){}); 

";//for testing whether part of list and getting option to add.

            string result = @" $(" + div + @").append('" + thelabel + ddl + tb + @"'); " + Lists + F0 + F1 + F2 + F3+F4+F5;

            //final ddl and sddl presentation handling
            result = result + @" $(ddl" + name + @").hide();  ";
            string docreadyfunction = @"$(document).ready(function(){P=$(tb" + name + @").position();    $(sddl" + name + @").css('position','fixed');  $(sddl" + name + @").css('z-index','20'); $(ddl" + name + @").css('position','fixed'); $(ddl" + name + @").css('z-index','20'); $(tb" + name + @").blur(function(){if(!(downarrowpress)){$(sddl" + name + @").hide();}}); ";
            
            if (ddlclass == "offset")//temp fix where some divs need adjustment of position relationships to parent
            {
                docreadyfunction = docreadyfunction + @"  $(sddl" + name + @").css('left',(P.left+$(" + div + @").position().left)); $(sddl" + name + @").css('top',(P.top+($(" + div + @").position().top)+$(tb" + name + @").height()+5)); $(ddl" + name + @").css('left',(P.left+$(" + div + @").position().left)); $(ddl" + name + @").css('top',(P.top+($(" + div + @").position().top)+$(tb" + name + @").height()+5));



});";
            }
            else
            {
                docreadyfunction = docreadyfunction + @"  $(sddl" + name + @").css('left',P.left); $(sddl" + name + @").css('top',(P.top+$(tb" + name + @").height()+5)); $(ddl" + name + @").css('left',P.left); $(ddl" + name + @").css('top',(P.top+$(tb" + name + @").height()+5));

             

});";
            }
            return result+docreadyfunction; 
        }
//        public string makeTBLddlInputPair(string type, string name, string ddlclass,string tbclass, string selected, string filter, int autotype, int subsize)
//        {
//            DRCMethods DRCM = new DRCMethods();
//            string tbval = ">";
//            string Lists = @" $(divLists).append('<select class=SUB" + ddlclass + @" id=sddl" + name + @"></select>'); ";
//            string ddl = @"<select class=" + ddlclass + @" id=ddl" + name + @">";
//            ddl = ddl + @"<option value=0>NEW ENTRY</option>";
//            string tb = @"<input type=text class=" + tbclass + @" id=tb" + name + @" ";

//            #region Selection List Types$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
//            switch (type)
//            {
//                case "STKBIN":
//                    List<DRC_ItemBin> Bin = DRCrepos.getItemBins(Convert.ToInt32(filter));
//                    foreach (DRC_ItemBin B in Bin)
//                    {
//                        ddl = ddl + @"<option value=" + B.BinID + @">" + B.Name + @"</option>";
//                    }
//                    if (Bin.Count > 0) tbval = @"value=" + Bin[0].Name + tbval;
//                    break;
//                case "STKBUILDING":
//                    List<DRC_ItemBuilding> Bldg = DRCrepos.getItemBuildings(Convert.ToInt32(filter));
//                    foreach (DRC_ItemBuilding B in Bldg)
//                    {
//                        ddl = ddl + @"<option value=" + B.BuildingID + @">" + B.Name + @"</option>";
//                    }
//                    if (Bldg.Count > 0) tbval = @"value=" + Bldg[0].Name + tbval;
//                    break;
//                case "STKROOM":
//                    List<DRC_ItemRoom> Room = DRCrepos.getItemRooms(Convert.ToInt32(filter));
//                    foreach (DRC_ItemRoom R in Room)
//                    {
//                        ddl = ddl + @"<option value=" + R.RoomID + @">" + R.Name + @"</option>";
//                    }
//                    if (Room.Count > 0) tbval = @"value=" + Room[0].Name + tbval;
//                    break;
//                case "ACCOUNTS":
//                    List<Account> al = DRCrepos.AccountList(Convert.ToInt32(filter));

//                    foreach (var a in al)
//                    {
//                        ddl = ddl + @"<option value=" + a.AccountID + @">" + DRCM.fixstring(a.Name) + @"</option>";
//                    }
//                    if (al.Count > 0) tbval = @"value=" + al[0].Name + tbval;
//                    break;

//                case "STATELIST":
//                    List<DRC_StateProvenceList> States = DRCrepos.getStates();
//                    foreach (DRC_StateProvenceList ST in States)
//                    {
//                        ddl = ddl + @"<option value=" + ST.StateID + @">" + DRCM.fixstring(ST.StateName) + @"</option>";

//                    }
//                    if (States.Count > 0) tbval = @"value=" + DRCM.fixstring(States[0].StateName) + tbval;
//                    break;
//                case "CITYLIST":
//                    List<DRC_CityList> Cities = DRCrepos.getCities();
//                    foreach (DRC_CityList CT in Cities)
//                    {
//                        ddl = ddl + @"<option value=" + CT.CityID + @">" + DRCM.fixstring(CT.Name) + @"</option>";

//                    }
//                    if (Cities.Count > 0) tbval = @"value=" + DRCM.fixstring(Cities[0].Name) + tbval;
//                    break;
//                case "COUNTRYLIST":
//                    List<DRC_CountryList> Country = DRCrepos.getCountries();
//                    foreach (DRC_CountryList CO in Country)
//                    {
//                        ddl = ddl + @"<option value=" + CO.CountryID + @">" + DRCM.fixstring(CO.Name) + @"</option>";

//                    }
//                    if (Country.Count > 0) tbval = @"value=" + DRCM.fixstring(Country[0].Name) + tbval;
//                    break;
//                case "TERMSLIST":
//                    List<DRC_Term> Terms = DRCrepos.getTerms();
//                    foreach (DRC_Term T in Terms)
//                    {
//                        ddl = ddl + @"<option value=" + T.TermsID + @">" + DRCM.fixstring(T.TermsDescription) + @"</option>";

//                    }
//                    if (Terms.Count > 0) tbval = @"value=" + DRCM.fixstring(Terms[0].TermsDescription) + tbval;
//                    break;
//                case "TAXLOCLIST":
//                    List<DRC_TaxCode> TaxCodes = DRCrepos.getTaxCodes();
//                    foreach (DRC_TaxCode TC in TaxCodes)
//                    {
//                        DRCMethods DM = new DRCMethods();
//                        double taxpercent = Math.Round(DM.makeTaxInfo(Convert.ToInt32(TC.TaxCodeID)).TaxPercent, 2);
//                        ddl = ddl + @"<option value=" + TC.TaxCodeID + @">" + TC.Name + @":" + DRCM.fixstring(TC.Description) + @"-" + taxpercent + @"%" + @"</option>";

//                    }
//                    if (TaxCodes.Count > 0) tbval = @"value=" + DRCM.fixstring(TaxCodes[0].Description) + tbval;
//                    break;
//                case "ItemType":
//                    List<DRC_PNCode> PNtype = DRCrepos.getPNCodes();
//                    foreach (DRC_PNCode PN in PNtype)
//                    {
//                        ddl = ddl + @"<option value=" + PN.Code + @">" + DRCM.fixstring(PN.ProductType) + @"</option>";
//                    }
//                    if (PNtype.Count > 0) tbval = @"value=" + DRCM.fixstring(PNtype[0].ProductType) + tbval;
//                    break;
//                case "ItemMan":
//                    List<DRC_ManCode> Man = DRCrepos.getManCodes();
//                    foreach (DRC_ManCode M in Man)
//                    {
//                        ddl = ddl + @"<option value=" + M.Code + @">" + DRCM.fixstring(M.Manufacturer) + @"</option>";
//                    }
//                    if (Man.Count > 0) tbval = @"value=" + DRCM.fixstring(Man[0].Manufacturer) + tbval;
//                    break;
//                case "ItemDescript":

//                    if (filter == "0:0")
//                    {
//                        filter = DRCrepos.getfirstItemTypeManIDSet();
//                    }
//                    int Itype = Convert.ToInt32(filter.Substring(0, (filter.LastIndexOf(':'))));
//                    int IMan = Convert.ToInt32(filter.Substring((filter.LastIndexOf(':') + 1)));

//                    List<DRC_ItemInvAccountTable> Items = DRCrepos.getItemsbyTypeAndMan(Itype, IMan);
//                    List<Account> Iacct = new List<Account>();
//                    foreach (DRC_ItemInvAccountTable item in Items)
//                    {
//                        Iacct.Add(DRCrepos.getAccount(Convert.ToInt32(item.AccountID)));
//                    }
//                    foreach (Account A in Iacct)
//                    {
//                        ddl = ddl + @"<option value=" + A.AccountID + @">" + DRCM.fixstring(A.Name) + @"</option>";
//                    }
//                    if (Iacct.Count > 0) tbval = @"value=" + DRCM.fixstring(Iacct[0].Name) + tbval;
//                    break;

//                case "ItemName":

//                    if (filter == "0:0")
//                    {
//                        filter = DRCrepos.getfirstItemTypeManIDSet();
//                    }
//                    int Ittype = Convert.ToInt32(filter.Substring(0, (filter.LastIndexOf(':'))));
//                    int ItMan = Convert.ToInt32(filter.Substring((filter.LastIndexOf(':') + 1)));

//                    List<DRC_ItemInvAccountTable> IItems = DRCrepos.getItemsbyTypeAndMan(Ittype, ItMan);
//                    List<Account> IIacct = new List<Account>();
//                    foreach (DRC_ItemInvAccountTable item in IItems)
//                    {
//                        IIacct.Add(DRCrepos.getAccount(Convert.ToInt32(item.AccountID)));
//                    }
//                    foreach (Account A in IIacct)
//                    {
//                        ddl = ddl + @"<option value=" + A.AccountID + @">" + DRCM.fixstring(A.AlphaPart) + @"</option>";
//                    }
//                    if (IIacct.Count > 0) tbval = @"value=" + DRCM.fixstring(IIacct[0].Name) + tbval;
//                    break;
//            }
//            #endregion
//            tb = tb + tbval;
//            ddl = ddl + @"</select>";

//            string F0 = @" var selval" + name + @"=0;";
//            if (selected == "") F0 = F0 + @" selval" + name + @"=document.getElementById('ddl" + name + @"').options[1].value;
//            document.getElementById('ddl" + name + @"').options[1].selected=true;
//            $(tb" + name + @").val(document.getElementById('ddl" + name + @"').options[1].text);
//            ";
//            else
//            {

//                F0 = F0 + @"  $(tb" + name + @").val('" + selected + @"');
//                            for (var i=0;i<document.getElementById('ddl" + name + @"').length;i++)
//                            {
//                                if(document.getElementById('ddl" + name + @"').options[i].text=='" + selected + @"')
//                                    {
//                                       selval" + name + @"= document.getElementById('ddl" + name + @"').options[i].value;
//                                       document.getElementById('ddl" + name + @"').options[i].selected=true;
//                                       
//                                    }
//                            } 
//
//";
//            }


//            string F1 = @"var l" + name + @"= 0; var idx" + name + @"=0; $(sddl" + name + @").hide(); var sidx" + name + @"=0; var  ddlval" + name + @"=0;
//              $(tb" + name + @").keyup(function(event)
//                {
//                    l" + name + @"=$(tb" + name + @").val().length;
//               
//                    try //error happens when tabbing but does not affect intended proccess so put in try group
//                    {
//                    
//                        if(l" + name + @">0)
//                            {
//                                $(ddl" + name + @").hide();
//                                $(sddl" + name + @").empty();
//                                $(sddl" + name + @").append('<option value=0>NEW ENTRY</option>');
//                                for (var i=1;i<document.getElementById('ddl" + name + @"').length;i++)
//                                    {
//                                        ddlval" + name + @"=document.getElementById('ddl" + name + @"').options[i].value;
//                                        if($(tb" + name + @").val()==document.getElementById('ddl" + name + @"').options[i].text)
//                                            {   
//                                                document.getElementById('ddl" + name + @"').options[i].selected=true;
//                                                selval" + name + @"= document.getElementById('ddl" + name + @"').options[i].value;
//                                            }
//                                        else{
//                                                document.getElementById('ddl" + name + @"').selectedIndex=-1;
//                                                selval" + name + @"=0;
//                                            }
//";

//            switch (autotype)
//            {
//                case 0:
//                    F1 = F1 + @"
//                                        
//                            
//                                        if(document.getElementById('ddl" + name + @"').options[i].text.substr(0,l" + name + @").toUpperCase()==$(tb" + name + @").val().toUpperCase())
//                                            {
//                                    
//                                    
//                                                $(sddl" + name + @").append('<option value='+ddlval" + name + @"+'>'+document.getElementById('ddl" + name + @"').options[i].text+'</option>');
//                                                sidx" + name + @"++;
//                                            }
//";


//                    break;
//                case 1:

//                    F1 = F1 + @"
//                                        if(document.getElementById('ddl" + name + @"').options[i].text.toUpperCase().lastIndexOf($(tb" + name + @").val().toUpperCase())>-1)
//                                            {
//                                    
//                                                $(sddl" + name + @").show();
//                                                $(sddl" + name + @").append('<option value='+ddlval" + name + @"+'>'+document.getElementById('ddl" + name + @"').options[i].text+'</option>');
//                                                sidx" + name + @"++;
//                                            
//}";

//                    break;

//                default:
//                    break;
//            }


//            F1 = F1 + @"
//                                        }//This is the end of the for loop
//                               var sddlLENGTH=document.getElementById('sddl" + name + @"').length;
//                                document.getElementById('sddl" + name + @"').selectedIndex=0;
//                                if (sddlLENGTH>0)
//                                            {
//                                                $(ddl" + name + @").hide();
//                                                $(sddl" + name + @").show();
//                                                if(sddlLENGTH<" + subsize + @")
//                                                    {
//                                                        $(sddl" + name + @").attr('size',sddlLENGTH);
//                                                    }
//                                                    else
//                                                    {
//                                                        $(sddl" + name + @").attr('size','" + subsize + @"');
//                                                    }
//                                            }
//                                        else
//                                            {
//                                                $(ddl" + name + @").show();
//                                                $(sddl" + name + @").hide();
//                                                
//                                            }
//                                
//                            }
//                        else
//                            {
//                            
//                                $(ddl" + name + @").show();
//                                $(sddl" + name + @").hide();
//                            }
//                    }
//                 catch(err)
//                    {
//                    }   
//            
//
//
//
//
//});";
//            string F2 = @"  $(ddl" + name + @").change(function(event){$(tb" + name + @").val(document.getElementById('ddl" + name + @"').options[document.getElementById('ddl" + name + @"').selectedIndex].text); selval" + name + @"=document.getElementById('ddl" + name + @"').options[document.getElementById('ddl" + name + @"').selectedIndex].value;
////showDetailsButton('" + name + @"');
//});";
//            string F3 = @" $(sddl" + name + @").change(function(event){$(tb" + name + @").val(document.getElementById('sddl" + name + @"').options[document.getElementById('sddl" + name + @"').selectedIndex].text); selval" + name + @"=document.getElementById('sddl" + name + @"').options[document.getElementById('sddl" + name + @"').selectedIndex].value; 
//
////showDetailsButton('" + name + @"');  
//$(sddl" + name + @").hide();}); ";
//            string F4 = @" function " + name + @"selmouseover(selectedidx)
//                          {
//                            
//                            alert(selectedidx);
//                          }
//                        function " + name + @"selmouseout(selectedidx)
//                          {
//                            alert(selectedidx);
//                          }
//
//
//            ";
//            string F5 = @" $(tb" + name + @").blur(function(){}); ";//for testing whether part of list and getting option to add.

//            string result = ddl + tb + Lists + F0 + F1 + F2 + F3 + F4 + F5;
//            return result;
//        }
        public string MakeInputPair(string lblclass, string ddlclass, string tbclass, string type, string div, string selected, string name, string filter, string lbl, string title, int autotype, int subsize, string changeaction, string SUBchangeaction,bool StartHideDDL)//autotype 0 for first characters, 1 for characters in any position
        {
            DRCMethods DRCM = new DRCMethods();
            string tbval = ">";
            string thelabel = @"<label id=lblddl" + name + @" class=" + lblclass + @">" + lbl + @"</label>";
            string Lists = @" $(divLists).append('<select class=SUB" + ddlclass + @" id=sddl" + name + @"></select>'); ";
            string ddl = @"<select class=" + ddlclass + @" id=ddl" + name + @">";
            ddl = ddl + @"<option value=0>NEW ENTRY</option>";
            string tb = @"<input type=text class=" + tbclass + @" id=tb" + name + @" ";

            #region Selection List Types$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
            switch (type)
            {
                case "STKBIN":
                    List<DRC_ItemBin> Bin = DRCrepos.getItemBins(Convert.ToInt32(filter));
                    foreach (DRC_ItemBin B in Bin)
                    {
                        ddl = ddl + @"<option value=" + B.BinID + @">" + B.Name + @"</option>";
                    }
                    if (Bin.Count > 0) tbval = @"value=" + Bin[0].Name + tbval;
                    break;
                case "STKBUILDING":
                    List<DRC_ItemBuilding> Bldg = DRCrepos.getItemBuildings(Convert.ToInt32(filter));
                    foreach (DRC_ItemBuilding B in Bldg)
                    {
                        ddl = ddl + @"<option value=" + B.BuildingID + @">" + B.Name + @"</option>";
                    }
                    if (Bldg.Count > 0) tbval = @"value=" + Bldg[0].Name + tbval;
                    break;
                case "STKROOM":
                    List<DRC_ItemRoom> Room = DRCrepos.getItemRooms(Convert.ToInt32(filter));
                    foreach (DRC_ItemRoom R in Room)
                    {
                        ddl = ddl + @"<option value=" + R.RoomID + @">" + R.Name + @"</option>";
                    }
                    if (Room.Count > 0) tbval = @"value=" + Room[0].Name + tbval;
                    break;
                case "ACCOUNTS":
                    List<Account> al = DRCrepos.AccountList(Convert.ToInt32(filter));

                    foreach (var a in al)
                    {
                        ddl = ddl + @"<option value=" + a.AccountID + @">" + DRCM.fixstring(a.Name) + @"</option>";
                    }
                    if (al.Count > 0) tbval = @"value=" + al[0].Name + tbval;
                    break;

                case "STATELIST":
                    List<DRC_StateProvenceList> States = DRCrepos.getStates();
                    foreach (DRC_StateProvenceList ST in States)
                    {
                        ddl = ddl + @"<option value=" + ST.StateID + @">" + DRCM.fixstring(ST.StateName) + @"</option>";

                    }
                    if (States.Count > 0) tbval = @"value=" + DRCM.fixstring(States[0].StateName) + tbval;
                    break;
                case "CITYLIST":
                    List<DRC_CityList> Cities = DRCrepos.getCities();
                    foreach (DRC_CityList CT in Cities)
                    {
                        ddl = ddl + @"<option value=" + CT.CityID + @">" + DRCM.fixstring(CT.Name) + @"</option>";

                    }
                    if (Cities.Count > 0) tbval = @"value=" + DRCM.fixstring(Cities[0].Name) + tbval;
                    break;
                case "COUNTRYLIST":
                    List<DRC_CountryList> Country = DRCrepos.getCountries();
                    foreach (DRC_CountryList CO in Country)
                    {
                        ddl = ddl + @"<option value=" + CO.CountryID + @">" + DRCM.fixstring(CO.Name) + @"</option>";

                    }
                    if (Country.Count > 0) tbval = @"value=" + DRCM.fixstring(Country[0].Name) + tbval;
                    break;
                case "TERMSLIST":
                    List<DRC_Term> Terms = DRCrepos.getTerms();
                    foreach (DRC_Term T in Terms)
                    {
                        ddl = ddl + @"<option value=" + T.TermsID + @">" + DRCM.fixstring(T.TermsDescription) + @"</option>";

                    }
                    if (Terms.Count > 0) tbval = @"value=" + DRCM.fixstring(Terms[0].TermsDescription) + tbval;
                    break;
                case "TAXLOCLIST":
                    List<DRC_TaxCode> TaxCodes = DRCrepos.getTaxCodes();
                    foreach (DRC_TaxCode TC in TaxCodes)
                    {
                        DRCMethods DM = new DRCMethods();
                        double taxpercent = Math.Round(DM.makeTaxInfo(Convert.ToInt32(TC.TaxCodeID)).TaxPercent, 2);
                        ddl = ddl + @"<option value=" + TC.TaxCodeID + @">" + TC.Name + @":" + DRCM.fixstring(TC.Description) + @"-" + taxpercent + @"%" + @"</option>";

                    }
                    if (TaxCodes.Count > 0) tbval = @"value=" + DRCM.fixstring(TaxCodes[0].Description) + tbval;
                    break;
                case "ItemType":
                    List<DRC_PNCode> PNtype = DRCrepos.getPNCodes();
                    foreach (DRC_PNCode PN in PNtype)
                    {
                        ddl = ddl + @"<option value=" + PN.Code + @">" + DRCM.fixstring(PN.ProductType) + @"</option>";
                    }
                    if (PNtype.Count > 0) tbval = @"value=" + DRCM.fixstring(PNtype[0].ProductType) + tbval;
                    break;
                case "ItemMan":
                    List<DRC_ManCode> Man = DRCrepos.getManCodes();
                    foreach (DRC_ManCode M in Man)
                    {
                        ddl = ddl + @"<option value=" + M.Code + @">" + DRCM.fixstring(M.Manufacturer) + @"</option>";
                    }
                    if (Man.Count > 0) tbval = @"value=" + DRCM.fixstring(Man[0].Manufacturer) + tbval;
                    break;
                case "ItemDescript":

                    if (filter == "0:0")
                    {
                        filter = DRCrepos.getfirstItemTypeManIDSet();
                    }
                    int Itype = Convert.ToInt32(filter.Substring(0, (filter.LastIndexOf(':'))));
                    int IMan = Convert.ToInt32(filter.Substring((filter.LastIndexOf(':') + 1)));

                    List<DRC_ItemInvAccountTable> Items = DRCrepos.getItemsbyTypeAndMan(Itype, IMan);
                    List<Account> Iacct = new List<Account>();
                    foreach (DRC_ItemInvAccountTable item in Items)
                    {
                        Iacct.Add(DRCrepos.getAccount(Convert.ToInt32(item.AccountID)));
                    }
                    foreach (Account A in Iacct)
                    {
                        ddl = ddl + @"<option value=" + A.AccountID + @">" + DRCM.fixstring(A.Name) + @"</option>";
                    }
                    if (Iacct.Count > 0) tbval = @"value=" + DRCM.fixstring(Iacct[0].Name) + tbval;
                    break;

                case "ItemName":

                    if (filter == "0:0")
                    {
                        filter = DRCrepos.getfirstItemTypeManIDSet();
                    }
                    int Ittype = Convert.ToInt32(filter.Substring(0, (filter.LastIndexOf(':'))));
                    int ItMan = Convert.ToInt32(filter.Substring((filter.LastIndexOf(':') + 1)));

                    List<DRC_ItemInvAccountTable> IItems = DRCrepos.getItemsbyTypeAndMan(Ittype, ItMan);
                    List<Account> IIacct = new List<Account>();
                    foreach (DRC_ItemInvAccountTable item in IItems)
                    {
                        IIacct.Add(DRCrepos.getAccount(Convert.ToInt32(item.AccountID)));
                    }
                    foreach (Account A in IIacct)
                    {
                        ddl = ddl + @"<option value=" + A.AccountID + @">" + DRCM.fixstring(A.AlphaPart) + @"</option>";
                    }
                    if (IIacct.Count > 0) tbval = @"value=" + DRCM.fixstring(IIacct[0].Name) + tbval;
                    break;

                case "CONTACT"://filter is for contact account id
                    List<DRC_Contact> contacts = new List<DRC_Contact>();
                    int acctid = Convert.ToInt32(filter);
                    var C = from c in db.DRC_Contacts where c.AccountID == acctid select c;
                    if (C.Count() > 0)
                    {

                        foreach (DRC_Contact con in C)
                        {
                            string pn = "";
                            if (con.MobilePhone1 != null && con.MobilePhone1.Length > 6)
                            {
                                pn = @"(" + con.MobilePhone1.Substring(0, 3) + @")" + con.MobilePhone1.Substring(4, 3) + @"-" + con.MobilePhone1.Substring(5, 4);
                            }
                            string ov = con.ContactID + @">" + con.FirstName + @" " + con.LastName + @" : " + pn;
                            if (selected == con.ContactID.ToString()) { selected = ov; }
                            ddl = ddl + @"<option value=" + ov + @"</option>";
                        }

                    }
                    else
                    {
                        selected = "NEW ENTRY";
                    }
                    break;

                case "JOBCODE"://Filter for job code type
                    List<JobCode> codes = new List<JobCode>();
                    int codetype = Convert.ToInt32(filter);
                    var JC = from c in db.JobCodes where c.CodeType == codetype select c;
                    foreach (JobCode code in JC)
                    {
                        ddl = ddl + @"<option value=" + code.CodeID + @">" + code.Code + @"</option>";
                    }
                    break;

                case "EQUIP":
                    List<DRC_CustDevice> dev = new List<DRC_CustDevice>();
                    int acct = Convert.ToInt32(filter);
                    var D = from d in db2.DRC_CustDevices where d.CustID == acct select d;
                    if (D.Count() > 0)
                    {
                        foreach (DRC_CustDevice DEV in D)
                        {
                            ddl = ddl + @"<option value=" + DEV.DeviceID + @">" + DEV.Name + @" sn:" + DEV.SN + @"</option>";
                        }
                    }
                    else
                    {
                        selected = "NEW ENTRY";
                    }
                    break;

                case "EQUIPTYPE":
                    List<DRC_CustomerDeviceType> DT = new List<DRC_CustomerDeviceType>();
                    int AcctID = Convert.ToInt32(filter);//keep customer added types from other customer lists
                    var DevT = from d in db2.DRC_CustomerDeviceTypes where d.AcctID==AcctID || d.AcctID==0 select d;
                    if (DevT.Count() > 0)
                    {
                       
                        foreach (DRC_CustomerDeviceType devt in DevT)
                        {
                            
                               ddl = ddl + @"<option value=" + devt.DeviceTypeID + @">" + devt.DeviceType + @"</option>";
                        }
                    }
                    
                    break;

                case "MANoverMODEL"://All models for all manufactures
                    List<DRC_ManCode> OvrMan = DRCrepos.getManCodes();
                    foreach (DRC_ManCode M in OvrMan)
                    {
                        ddl = ddl + @"<option value=" + M.Code + @">" + DRCM.fixstring(M.Manufacturer) + @"</option>";
                    }
                    if (OvrMan.Count > 0) tbval = @"value=" + DRCM.fixstring(OvrMan[0].Manufacturer) + tbval;
                    break;

                case "ITEMMODEL":

                    List<DRC_ItemModel> IM = new List<DRC_ItemModel>();

                    var I = from m in db.DRC_ItemModels where m.ManID == Convert.ToInt32(filter) select m;

                    if (I.Count() > 0)
                    {
                        foreach (DRC_ItemModel item in I)
                        {
                            ddl = ddl + @"<option value=" + item.ModelID + @">" + item.Name + @"</option>";
                        }
                    }

                    else selected = "NEW ENTRY";

                    break;
                case "WARANTY":

                    List<DRC_Warranty> W = DRCrepos.getWarranties();
                    if (W.Count > 0)
                    {
                        foreach (DRC_Warranty item in W)
                        {
                            ddl = ddl + @"<option value=" + item.WarantyID + @">" + item.Name + @"</option>";
                        }
                    }
                    else selected = "NEW ENTRY";

                    break;

                case "CONTRACT":
                    List<DRC_Contract> Cnrt = DRCrepos.getContracts(Convert.ToInt32(filter));

                    if (Cnrt.Count > 0)
                    {
                        foreach (DRC_Contract item in Cnrt)
                        {
                            ddl = ddl + @"<option value=" + item.ContractID + @">" + DRCrepos.getContractNamefromTypeID(Convert.ToInt32(item.ContractTypeID)) + @"</option>";
                        }
                    }
                    else selected = "";


                    break;

                case "EQLOCATION":
                    List<DRC_CustDeviceLocation> dl = DRCrepos.getDeviceLocations(Convert.ToInt32(filter));

                    if (dl.Count > 0)
                    {
                        foreach (DRC_CustDeviceLocation item in dl)
                        {
                            ddl = ddl + @"<option value=" + item.LocationID + @">" + item.Name + @"</option>";
                        }
                    }
                    else selected = "";
                    break;

                case "STATUS":
                    var sta =
                                    from s in db.JobCodes
                                    where s.CodeType == 1
                                    select s;
                    foreach (var st in sta)
                    {
                        if (selected == st.CodeID.ToString())
                        {
                            ddl = ddl + @"<option selected=selected value=" + st.CodeID + @">" + st.Code + @"</option>";
                            selected = st.Code;
                        }
                        else ddl = ddl + @"<option value=" + st.CodeID + @">" + st.Code + @"</option>";
                    }
                    break;
                case "ENTITYTYPE":
                    List<DRC_CustEntityType> CE = DRCrepos.getEntitiesByAcctID(Convert.ToInt32(filter));
            foreach (DRC_CustEntityType ET in CE)
            {
                ddl=ddl + @"<option value="+ET.CustEntityTypeID+@" >"+ET.CustEntityType+@"</option>";
            }


                    break;
            }
            #endregion
            tb = tb + tbval;
            ddl = ddl + @"</select>";

            string F0 = @" var selval" + name + @"=0; var downarrowpress=false; ";
            if (selected == "") F0 = F0 + @" selval" + name + @"=document.getElementById('ddl" + name + @"').options[0].value;
            document.getElementById('ddl" + name + @"').options[0].selected=true;
            $(tb" + name + @").val('');
            ";
            else
            {

                F0 = F0 + @"  $(tb" + name + @").val('" + selected + @"');
                            for (var i=0;i<document.getElementById('ddl" + name + @"').length;i++)
                            {
                                if(document.getElementById('ddl" + name + @"').options[i].text=='" + selected + @"')
                                    {
                                       selval" + name + @"= document.getElementById('ddl" + name + @"').options[i].value;
                                       document.getElementById('ddl" + name + @"').options[i].selected=true;
                                       
                                    }
                            } 

";
            }


            string F1 = @"var l" + name + @"= 0; var idx" + name + @"=0; $(sddl" + name + @").hide(); var sidx" + name + @"=0; var  ddlval" + name + @"=0;
              $(tb" + name + @").keyup(function(event)
                {
                    l" + name + @"=$(tb" + name + @").val().length;
               

                    try //error happens when tabbing but does not affect intended proccess so put in try group
                    {
                    
                        if(l" + name + @">0)
                            {
                                $(ddl" + name + @").hide();
                                $(sddl" + name + @").empty();
                                $(sddl" + name + @").append('<option value=0>NEW ENTRY</option>');
                                for (var i=1;i<document.getElementById('ddl" + name + @"').length;i++)
                                    {
                                        ddlval" + name + @"=document.getElementById('ddl" + name + @"').options[i].value;
                                        if($(tb" + name + @").val()==document.getElementById('ddl" + name + @"').options[i].text)
                                            {   
                                                document.getElementById('ddl" + name + @"').options[i].selected=true;
                                                selval" + name + @"= document.getElementById('ddl" + name + @"').options[i].value;
                                            }
                                        else{
                                                document.getElementById('ddl" + name + @"').selectedIndex=-1;
                                                selval" + name + @"=0;
                                            }
                        
";

            switch (autotype)
            {
                case 0:
                    F1 = F1 + @"
                                        
                            
                                        if(document.getElementById('ddl" + name + @"').options[i].text.substr(0,l" + name + @").toUpperCase()==$(tb" + name + @").val().toUpperCase())
                                            {
                                    
                                    
                                                $(sddl" + name + @").append('<option value='+ddlval" + name + @"+'>'+document.getElementById('ddl" + name + @"').options[i].text+'</option>');
                                                sidx" + name + @"++;
                                            }

                                        
";


                    break;
                case 1:

                    F1 = F1 + @"
                                        if(document.getElementById('ddl" + name + @"').options[i].text.toUpperCase().lastIndexOf($(tb" + name + @").val().toUpperCase())>-1)
                                            {
                                    
                                                $(sddl" + name + @").show();
                                                $(sddl" + name + @").append('<option value='+ddlval" + name + @"+'>'+document.getElementById('ddl" + name + @"').options[i].text+'</option>');
                                                sidx" + name + @"++;
                                            
}";

                    break;

                default:
                    break;
            }


            F1 = F1 + @"
                                        }//This is the end of the for loop
                               var sddlLENGTH=document.getElementById('sddl" + name + @"').length;
                                document.getElementById('sddl" + name + @"').selectedIndex=0;
                                if (sddlLENGTH>0)
                                            {
                                                $(ddl" + name + @").hide();
                                                $(sddl" + name + @").show();
                                                if(event.keyCode==40)
                                                {(sddl" + name + @").focus(); downarrowpress=true;}
                                                else
                                                {downarrowpress=false;}
                                                if(sddlLENGTH<" + subsize + @")
                                                    {
                                                        $(sddl" + name + @").attr('size',sddlLENGTH);
                                                    }
                                                    else
                                                    {
                                                        $(sddl" + name + @").attr('size','" + subsize + @"');
                                                    }
                                            }
                                        else
                                            {
                                                $(ddl" + name + @").show();
                                                $(sddl" + name + @").hide();
                                                
                                            }
                                
                            }
                        else
                            {
                            
                                $(ddl" + name + @").show();
                                $(sddl" + name + @").hide();
                            }
                        P=$(tb" + name + @").position();
                        $(sddl" + name + @").css('left',P.left); $(sddl" + name + @").css('top',(P.top+$(tb" + name + @").height()+5)); $(ddl" + name + @").css('left',P.left); $(ddl" + name + @").css('top',(P.top+$(tb" + name + @").height()+5));
                    }
                 catch(err)
                    {
                    }   
            




});";
            string F2 = @"  $(ddl" + name + @").change(function(event){$(tb" + name + @").val(document.getElementById('ddl" + name + @"').options[document.getElementById('ddl" + name + @"').selectedIndex].text); selval" + name + @"=document.getElementById('ddl" + name + @"').options[document.getElementById('ddl" + name + @"').selectedIndex].value; $(ddl" + name + @").hide(); "+changeaction+@"  



            }); ";

            string F3 = @" $(sddl" + name + @").change(function(event){$(tb" + name + @").val(document.getElementById('sddl" + name + @"').options[document.getElementById('sddl" + name + @"').selectedIndex].text);

selval" + name + @"=document.getElementById('sddl" + name + @"').options[document.getElementById('sddl" + name + @"').selectedIndex].value; 
$(sddl" + name + @").hide(); " + SUBchangeaction + @"         

            
                    }); ";


                    


                    
    
               
            
            

           
            string F4 = @" function " + name + @"selmouseover(selectedidx)
                          {
                            
                            alert(selectedidx);
                          }
                        function " + name + @"selmouseout(selectedidx)
                          {
                            alert(selectedidx);
                          }


            ";
            string F5 = @" $(tb" + name + @").blur(function(){}); 

";//for testing whether part of list and getting option to add.

            string result = @" $(" + div + @").append('" + thelabel + ddl + tb + @"'); " + Lists + F0 + F1 + F2 + F3 + F4 +F5;

            //final ddl and sddl presentation handling
            if(StartHideDDL) result = result + @" $(ddl" + name + @").hide();  ";
            string docreadyfunction = @"$(document).ready(function(){P=$(tb" + name + @").position();    $(sddl" + name + @").css('position','absolute');  $(sddl" + name + @").css('z-index','20'); $(ddl" + name + @").css('position','absolute'); $(ddl" + name + @").css('z-index','20'); $(tb" + name + @").blur(function(){if(!(downarrowpress)){$(sddl" + name + @").hide();}});

}); ";

            return result + docreadyfunction;
        }
        public string MakeDDLDependentPair(string lblclass,string lbldclass, string ddlclass,string ddldclass, string tbclass, string tbdclass,string type, string div, string selected,string Dselected ,string name, string filter, string lbltxt, string lbldtxt, string title,string Dtitle, int autotype, int subsize, bool StartHideDDL)//autotype 0 for first characters, 1 for characters in any position
        {
            DRCMethods DRCM = new DRCMethods();
            string tbval = ">";
            string tbDval = ">";
            string thelabel = @"<label id=lblddl" + name + @" class=" + lblclass + @">" + lbltxt + @"</label>";
            string theDlabel = @"<label id=lblddlD" + name + @" class=" + lblclass + @">" + lbldtxt + @"</label>";

            string Lists = @" $(divLists).append('<select class=SUB" + ddlclass + @" id=sddl" + name + @"></select>'); ";
            string ListsD = @" $(divLists).append('<select class=SUB" + ddlclass + @" id=sddlD" + name + @"></select>'); ";
            string ddl = @"<select class=" + ddlclass + @" id=ddl" + name + @">";
            
            string ddlD = @"<select class=" + ddlclass + @" id=ddlD" + name + @">";
            
            string tb = @"<input type=text class=" + tbclass + @" title="+title+@" id=tb" + name + @" ";
            string tbD = @"<input type=text class=" + tbclass + @" title="+Dtitle+@" id=tbD" + name + @" ";
            string F0 = @" var selval" + name + @"=0; var selvalD" + name + @"=0; var downarrowpress=false; var downarrowpressD=false; document.getElementById('ddlD" + name + @"').options[0].selected=true;  $(tbD" + name + @").val(''); ";

            #region Selection List Types$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
            switch (type)
            {
               
                case "MANoverMODEL"://All models for all manufactures
                    ddl = ddl + @"<option value=0>NEW MANUFACTURER</option>";
                    ddlD = ddlD + @"<option value=0>NEW MODEL</option>";
                    int mCode=0;
                    int mdlCode = 0;
                    if (!(Dselected == "")) mdlCode = Convert.ToInt32(Dselected);
                    if (mdlCode > 0) Dselected = DRCrepos.getModelNamefromModelID(mdlCode);
                    else Dselected = "";
                    
                    if (!(selected == "")) mCode = Convert.ToInt32(selected);
                    List<DRC_ManCode> OvrMan = DRCrepos.getManCodes();
                    
                    foreach (DRC_ManCode M in OvrMan)
                    {
                        ddl = ddl + @"<option value=" + M.Code + @" ";
                        if (M.Code == mCode)
                        {
                            ddl = ddl + @"selected=selected";
                            F0 = F0 + @"selval" + name + @"=" + M.Code + @"; ";

                            selected = M.Manufacturer;//convert selection from ID to name
                        }
                        
                        ddl=ddl+@">" + DRCM.fixstring(M.Manufacturer) + @"</option>";
                    }

                    
                    
                    if (OvrMan.Count > 0)
                    {
                        
                        
                        List<DRC_ItemModel> IM = DRCrepos.getManModels(mCode);
                            foreach (DRC_ItemModel item in IM)
                            {
                                ddlD = ddlD + @"<option value=" + item.ModelID + @" ";
                                if(item.ModelID==mdlCode)
                                {
                                    ddlD=ddlD+@"selected=selected";
                                    F0=F0+@"selvalD"+name+@"="+item.ModelID+@"; ";
                                    Dselected=item.Name;
                                }
                                ddlD=ddlD+@">" + DRCM.fixstring(item.Name) + @"</option>";
                            }
                            if (IM.Count() > 0)
                            {
                              //  tbDval = @"value=" + DRCM.fixstring(IM[0].Name) + tbDval;
                        }
                    }
                    break;

            }
            #endregion
            tb = tb + tbval;
            tbD = tbD + tbDval;
            ddl = ddl + @"</select>";
            ddlD = ddlD + @"</select>";


            if (!(selected == ""))
            {

                F0 = F0 + @"  $(tb" + name + @").val('" + selected + @"'); ";
//                            
            }
            if (!(Dselected == "")) F0 = F0 + @" $(tbD" + name + @").val('" + Dselected + @"'); ";

            
            #region F1
            string F1 = @"var l" + name + @"= 0; var idx" + name + @"=0; $(sddl" + name + @").hide(); var sidx" + name + @"=0; var  ddlval" + name + @"=0;
              $(tb" + name + @").keyup(function(event)
                {
                    l" + name + @"=$(tb" + name + @").val().length;
               

                    try //error happens when tabbing but does not affect intended proccess so put in try group
                    {
                    
                        if(l" + name + @">0)
                            {
                                $(ddl" + name + @").hide();
                                $(sddl" + name + @").empty();
                                $(sddl" + name + @").append('<option value=0>NEW ENTRY</option>');
                                for (var i=1;i<document.getElementById('ddl" + name + @"').length;i++)
                                    {
                                        ddlval" + name + @"=document.getElementById('ddl" + name + @"').options[i].value;
                                        if($(tb" + name + @").val()==document.getElementById('ddl" + name + @"').options[i].text)
                                            {   
                                                document.getElementById('ddl" + name + @"').options[i].selected=true;
                                                selval" + name + @"= document.getElementById('ddl" + name + @"').options[i].value;
                                            }
                                        else{
                                                document.getElementById('ddl" + name + @"').selectedIndex=-1;
                                                selval" + name + @"=0;
                                            }
                        
";

            switch (autotype)
            {
                case 0:
                    F1 = F1 + @"
                                        
                            
                                        if(document.getElementById('ddl" + name + @"').options[i].text.substr(0,l" + name + @").toUpperCase()==$(tb" + name + @").val().toUpperCase())
                                            {
                                    
                                    
                                                $(sddl" + name + @").append('<option value='+ddlval" + name + @"+'>'+document.getElementById('ddl" + name + @"').options[i].text+'</option>');
                                                sidx" + name + @"++;
                                            }

                                        
";


                    break;
                case 1:

                    F1 = F1 + @"
                                        if(document.getElementById('ddl" + name + @"').options[i].text.toUpperCase().lastIndexOf($(tb" + name + @").val().toUpperCase())>-1)
                                            {
                                    
                                                $(sddl" + name + @").show();
                                                $(sddl" + name + @").append('<option value='+ddlval" + name + @"+'>'+document.getElementById('ddl" + name + @"').options[i].text+'</option>');
                                                sidx" + name + @"++;
                                            
}";

                    break;

                default:
                    break;
            }


            F1 = F1 + @"
                                        }//This is the end of the for loop
                               var sddlLENGTH=document.getElementById('sddl" + name + @"').length;
                                document.getElementById('sddl" + name + @"').selectedIndex=0;
                                if (sddlLENGTH>0)
                                            {
                                                $(ddl" + name + @").hide();
                                                $(sddl" + name + @").show();
                                                if(event.keyCode==40)
                                                {(sddl" + name + @").focus(); downarrowpress=true;}
                                                else
                                                {downarrowpress=false;}
                                                if(sddlLENGTH<" + subsize + @")
                                                    {
                                                        $(sddl" + name + @").attr('size',sddlLENGTH);
                                                    }
                                                    else
                                                    {
                                                        $(sddl" + name + @").attr('size','" + subsize + @"');
                                                    }
                                            }
                                        else
                                            {
                                                $(ddl" + name + @").show();
                                                $(sddl" + name + @").hide();
                                                
                                            }
                                
                            }
                        else
                            {
                            
                                $(ddl" + name + @").show();
                                $(sddl" + name + @").hide();
                            }
                        P=$(tb" + name + @").position();
                        $(sddl" + name + @").css('left',P.left); $(sddl" + name + @").css('top',(P.top+$(tb" + name + @").height()+5)); $(ddl" + name + @").css('left',P.left); $(ddl" + name + @").css('top',(P.top+$(tb" + name + @").height()+5));
                    }
                 catch(err)
                    {
                    }   
            




});";
            #endregion
            #region F1D
            string F1D = @"var lD" + name + @"= 0; var idxD" + name + @"=0; $(sddlD" + name + @").hide(); var sidxD" + name + @"=0; var  ddlvalD" + name + @"=0;
              $(tbD" + name + @").keyup(function(event)
                {
                    lD" + name + @"=$(tbD" + name + @").val().length;
               

                    try //error happens when tabbing but does not affect intended proccess so put in try group
                    {
                    
                        if(lD" + name + @">0)
                            {
                                $(ddlD" + name + @").hide();
                                $(sddlD" + name + @").empty();
                                $(sddlD" + name + @").append('<option value=0>NEW ENTRY</option>');
                                for (var i=1;i<document.getElementById('ddlD" + name + @"').length;i++)
                                    {
                                        ddlvalD" + name + @"=document.getElementById('ddlD" + name + @"').options[i].value;
                                        if($(tbD" + name + @").val()==document.getElementById('ddlD" + name + @"').options[i].text)
                                            {   
                                                document.getElementById('ddlD" + name + @"').options[i].selected=true;
                                                selvalD" + name + @"= document.getElementById('ddlD" + name + @"').options[i].value;
                                            }
                                        else{
                                                document.getElementById('ddlD" + name + @"').selectedIndex=-1;
                                                selvalD" + name + @"=0;
                                            }
                        
";

            switch (autotype)
            {
                case 0:
                    F1D = F1D + @"
                                        
                            
                                        if(document.getElementById('ddlD" + name + @"').options[i].text.substr(0,lD" + name + @").toUpperCase()==$(tbD" + name + @").val().toUpperCase())
                                            {
                                    
                                    
                                                $(sddlD" + name + @").append('<option value='+ddlvalD" + name + @"+'>'+document.getElementById('ddlD" + name + @"').options[i].text+'</option>');
                                                sidxD" + name + @"++;
                                            }

                                        
";


                    break;
                case 1:

                    F1D = F1D + @"
                                        if(document.getElementById('ddlD" + name + @"').options[i].text.toUpperCase().lastIndexOf($(tbD" + name + @").val().toUpperCase())>-1D)
                                            {
                                    
                                                $(sddlD" + name + @").show();
                                                $(sddlD" + name + @").append('<option value='+ddlvalD" + name + @"+'>'+document.getElementById('ddlD" + name + @"').options[i].text+'</option>');
                                                sidxD" + name + @"++;
                                            
}";

                    break;

                default:
                    break;
            }


            F1D = F1D + @"
                                        }//This is the end of the for loop
                               var sddlLENGTHD=document.getElementById('sddlD" + name + @"').length;
                                document.getElementById('sddlD" + name + @"').selectedIndex=0;
                                if (sddlLENGTHD>0)
                                            {
                                                $(ddlD" + name + @").hide();
                                                $(sddlD" + name + @").show();
                                                if(event.keyCode==40)
                                                {(sddlD" + name + @").focus(); downarrowpressD=true;}
                                                else
                                                {downarrowpressD=false;}
                                                if(sddlLENGTHD<" + subsize + @")
                                                    {
                                                        $(sddlD" + name + @").attr('size',sddlLENGTHD);
                                                    }
                                                    else
                                                    {
                                                        $(sddlD" + name + @").attr('size','" + subsize + @"');
                                                    }
                                            }
                                        else
                                            {
                                                $(ddlD" + name + @").show();
                                                $(sddlD" + name + @").hide();
                                                
                                            }
                                
                            }
                        else
                            {
                            
                                $(ddlD" + name + @").show();
                                $(sddlD" + name + @").hide();
                            }
                        P=$(tbD" + name + @").position();
                        $(sddlD" + name + @").css('left',P.left); $(sddlD" + name + @").css('top',(P.top+$(tbD" + name + @").height()+5)); $(ddlD" + name + @").css('left',P.left); $(ddlD" + name + @").css('top',(P.top+$(tbD" + name + @").height()+5));
                    }
                 catch(err)
                    {
                    }   
            




});";
            #endregion
            
            string F2 = @"  $(ddl" + name + @").change(function(event){$(tb" + name + @").val(document.getElementById('ddl" + name + @"').options[document.getElementById('ddl" + name + @"').selectedIndex].text); selval" + name + @"=document.getElementById('ddl" + name + @"').options[document.getElementById('ddl" + name + @"').selectedIndex].value; $(ddl" + name + @").hide();
                    $.post('/DRCCustomer/PopulateDependentDDL', {ddlID:'ddlD" + name + @"',type:'" + type + @"',key:selval" + name + @"}); 


                                }); ";

            string F2D = @"  $(ddlD" + name + @").change(function(event){$(tbD" + name + @").val(document.getElementById('ddlD" + name + @"').options[document.getElementById('ddlD" + name + @"').selectedIndex].text); selvalD" + name + @"=document.getElementById('ddlD" + name + @"').options[document.getElementById('ddlD" + name + @"').selectedIndex].value; $(ddlD" + name + @").hide(); 
                    

                                }); ";

            #region add this
            string F3 = @" $(sddl" + name + @").change(function(event){$(tb" + name + @").val(document.getElementById('sddl" + name + @"').options[document.getElementById('sddl" + name + @"').selectedIndex].text); selval" + name + @"=document.getElementById('sddl" + name + @"').options[document.getElementById('sddl" + name + @"').selectedIndex].value; 
$.post('/DRCCustomer/PopulateDependentDDL', {ddlID:'ddlD" + name + @"',type:'" + type + @"',key:selval" + name + @"});

$(sddl" + name + @").hide();



                    }); ";

            string F3D = @" $(sddlD" + name + @").change(function(event){$(tbD" + name + @").val(document.getElementById('sddlD" + name + @"').options[document.getElementById('sddlD" + name + @"').selectedIndex].text); selvalD" + name + @"=document.getElementById('sddlD" + name + @"').options[document.getElementById('sddlD" + name + @"').selectedIndex].value; 


$(sddlD" + name + @").hide();



                    }); ";




            #endregion
            string result = @" $(" + div + @").append('" + thelabel + ddl + tb + theDlabel + ddlD + tbD + @"'); " + Lists + ListsD + F0 + F1 + F1D + F2 +F2D+ F3 + F3D;// F4 + F5;

            //final ddl and sddl presentation handling
if(StartHideDDL) result = result + @" $(ddl" + name + @").hide(); $(ddlD" + name + @").hide(); ";
            string docreadyfunction = @"$(document).ready(function(){P=$(tb" + name + @").position();  PD=$(tbD" + name + @").position();  $(sddl" + name + @").css('position','absolute'); $(sddlD" + name + @").css('position','absolute'); $(sddl" + name + @").css('z-index','20'); $(sddlD" + name + @").css('z-index','20'); $(ddl" + name + @").css('position','absolute'); $(ddlD" + name + @").css('position','absolute'); $(ddl" + name + @").css('z-index','20'); $(ddlD" + name + @").css('z-index','20'); $(tb" + name + @").blur(function(){if(!(downarrowpress)){$(sddl" + name + @").hide();}}); $(tbD" + name + @").blur(function(){if(!(downarrowpressD)){$(sddlD" + name + @").hide();}});

}); ";


            return result +docreadyfunction;
        }
        public string MakeTableInputPair(string ddlclass, string tbclass, string type, string div, string selected, string name, string filter, string title, int autotype, int subsize)//autotype 0 for first characters, 1 for characters in any position
        {
            DRCMethods DRCM = new DRCMethods();
            string tbval = ">";
            string Lists = @"<select class=SUB" + ddlclass + @" id=sddl" + name + @"></select>; ";
            string ddl = @"<select class=" + ddlclass + @" id=ddl" + name + @">";
            ddl = ddl + @"<option value=0>NEW ENTRY</option>";
            string tb = @"<input type=text class=" + tbclass + @" id=tb" + name + @" ";

            #region Selection List Types$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
            switch (type)
            {
                case "STKBIN":
                    List<DRC_ItemBin> Bin = DRCrepos.getItemBins(Convert.ToInt32(filter));
                    foreach (DRC_ItemBin B in Bin)
                    {
                        ddl = ddl + @"<option value=" + B.BinID + @">" + B.Name + @"</option>";
                    }
                    if (Bin.Count > 0) tbval = @"value=" + Bin[0].Name + tbval;
                    break;
                case "STKBUILDING":
                    List<DRC_ItemBuilding> Bldg = DRCrepos.getItemBuildings(Convert.ToInt32(filter));
                    foreach (DRC_ItemBuilding B in Bldg)
                    {
                        ddl = ddl + @"<option value=" + B.BuildingID + @">" + B.Name + @"</option>";
                    }
                    if (Bldg.Count > 0) tbval = @"value=" + Bldg[0].Name + tbval;
                    break;
                case "STKROOM":
                    List<DRC_ItemRoom> Room = DRCrepos.getItemRooms(Convert.ToInt32(filter));
                    foreach (DRC_ItemRoom R in Room)
                    {
                        ddl = ddl + @"<option value=" + R.RoomID + @">" + R.Name + @"</option>";
                    }
                    if (Room.Count > 0) tbval = @"value=" + Room[0].Name + tbval;
                    break;
                case "ACCOUNTS":
                    List<Account> al = DRCrepos.AccountList(Convert.ToInt32(filter));

                    foreach (var a in al)
                    {
                        ddl = ddl + @"<option value=" + a.AccountID + @">" + DRCM.fixstring(a.Name) + @"</option>";
                    }
                    if (al.Count > 0) tbval = @"value=" + al[0].Name + tbval;
                    break;

                case "STATELIST":
                    List<DRC_StateProvenceList> States = DRCrepos.getStates();
                    foreach (DRC_StateProvenceList ST in States)
                    {
                        ddl = ddl + @"<option value=" + ST.StateID + @">" + DRCM.fixstring(ST.StateName) + @"</option>";

                    }
                    if (States.Count > 0) tbval = @"value=" + DRCM.fixstring(States[0].StateName) + tbval;
                    break;
                case "CITYLIST":
                    List<DRC_CityList> Cities = DRCrepos.getCities();
                    foreach (DRC_CityList CT in Cities)
                    {
                        ddl = ddl + @"<option value=" + CT.CityID + @">" + DRCM.fixstring(CT.Name) + @"</option>";

                    }
                    if (Cities.Count > 0) tbval = @"value=" + DRCM.fixstring(Cities[0].Name) + tbval;
                    break;
                case "COUNTRYLIST":
                    List<DRC_CountryList> Country = DRCrepos.getCountries();
                    foreach (DRC_CountryList CO in Country)
                    {
                        ddl = ddl + @"<option value=" + CO.CountryID + @">" + DRCM.fixstring(CO.Name) + @"</option>";

                    }
                    if (Country.Count > 0) tbval = @"value=" + DRCM.fixstring(Country[0].Name) + tbval;
                    break;
                case "TERMSLIST":
                    List<DRC_Term> Terms = DRCrepos.getTerms();
                    foreach (DRC_Term T in Terms)
                    {
                        ddl = ddl + @"<option value=" + T.TermsID + @">" + DRCM.fixstring(T.TermsDescription) + @"</option>";

                    }
                    if (Terms.Count > 0) tbval = @"value=" + DRCM.fixstring(Terms[0].TermsDescription) + tbval;
                    break;
                case "TAXLOCLIST":
                    List<DRC_TaxCode> TaxCodes = DRCrepos.getTaxCodes();
                    foreach (DRC_TaxCode TC in TaxCodes)
                    {
                        DRCMethods DM = new DRCMethods();
                        double taxpercent = Math.Round(DM.makeTaxInfo(Convert.ToInt32(TC.TaxCodeID)).TaxPercent, 2);
                        ddl = ddl + @"<option value=" + TC.TaxCodeID + @">" + TC.Name + @":" + DRCM.fixstring(TC.Description) + @"-" + taxpercent + @"%" + @"</option>";

                    }
                    if (TaxCodes.Count > 0) tbval = @"value=" + DRCM.fixstring(TaxCodes[0].Description) + tbval;
                    break;
                case "ItemType":
                    List<DRC_PNCode> PNtype = DRCrepos.getPNCodes();
                    foreach (DRC_PNCode PN in PNtype)
                    {
                        ddl = ddl + @"<option value=" + PN.Code + @">" + DRCM.fixstring(PN.ProductType) + @"</option>";
                    }
                    if (PNtype.Count > 0) tbval = @"value=" + DRCM.fixstring(PNtype[0].ProductType) + tbval;
                    break;
                case "ItemMan":
                    List<DRC_ManCode> Man = DRCrepos.getManCodes();
                    foreach (DRC_ManCode M in Man)
                    {
                        ddl = ddl + @"<option value=" + M.Code + @">" + DRCM.fixstring(M.Manufacturer) + @"</option>";
                    }
                    if (Man.Count > 0) tbval = @"value=" + DRCM.fixstring(Man[0].Manufacturer) + tbval;
                    break;
                case "ItemDescript":

                    if (filter == "0:0")
                    {
                        filter = DRCrepos.getfirstItemTypeManIDSet();
                    }
                    int Itype = Convert.ToInt32(filter.Substring(0, (filter.LastIndexOf(':'))));
                    int IMan = Convert.ToInt32(filter.Substring((filter.LastIndexOf(':') + 1)));

                    List<DRC_ItemInvAccountTable> Items = DRCrepos.getItemsbyTypeAndMan(Itype, IMan);
                    List<Account> Iacct = new List<Account>();
                    foreach (DRC_ItemInvAccountTable item in Items)
                    {
                        Iacct.Add(DRCrepos.getAccount(Convert.ToInt32(item.AccountID)));
                    }
                    foreach (Account A in Iacct)
                    {
                        ddl = ddl + @"<option value=" + A.AccountID + @">" + DRCM.fixstring(A.Name) + @"</option>";
                    }
                    if (Iacct.Count > 0) tbval = @"value=" + DRCM.fixstring(Iacct[0].Name) + tbval;
                    break;

                case "ItemName":

                    if (filter == "0:0")
                    {
                        filter = DRCrepos.getfirstItemTypeManIDSet();
                    }
                    int Ittype = Convert.ToInt32(filter.Substring(0, (filter.LastIndexOf(':'))));
                    int ItMan = Convert.ToInt32(filter.Substring((filter.LastIndexOf(':') + 1)));

                    List<DRC_ItemInvAccountTable> IItems = DRCrepos.getItemsbyTypeAndMan(Ittype, ItMan);
                    List<Account> IIacct = new List<Account>();
                    foreach (DRC_ItemInvAccountTable item in IItems)
                    {
                        IIacct.Add(DRCrepos.getAccount(Convert.ToInt32(item.AccountID)));
                    }
                    foreach (Account A in IIacct)
                    {
                        ddl = ddl + @"<option value=" + A.AccountID + @">" + DRCM.fixstring(A.AlphaPart) + @"</option>";
                    }
                    if (IIacct.Count > 0) tbval = @"value=" + DRCM.fixstring(IIacct[0].Name) + tbval;
                    break;

                case "CONTACT"://filter is for contact account id
                    List<DRC_Contact> contacts = new List<DRC_Contact>();
                    int acctid = Convert.ToInt32(filter);
                    var C = from c in db.DRC_Contacts where c.AccountID == acctid select c;
                    if (C.Count() > 0)
                    {

                        foreach (DRC_Contact con in C)
                        {
                            string pn = "";
                            if (con.MobilePhone1 != null && con.MobilePhone1.Length > 6)
                            {
                                pn = @"(" + con.MobilePhone1.Substring(0, 3) + @")" + con.MobilePhone1.Substring(4, 3) + @"-" + con.MobilePhone1.Substring(5, 4);
                            }
                            string ov = con.ContactID + @">" + con.FirstName + @" " + con.LastName + @" : " + pn;
                            if (selected == con.ContactID.ToString()) { selected = ov; }
                            ddl = ddl + @"<option value=" + ov + @"</option>";
                        }

                    }
                    else
                    {
                        selected = "NEW ENTRY";
                    }
                    break;

                case "JOBCODE"://Filter for job code type
                    List<JobCode> codes = new List<JobCode>();
                    int codetype = Convert.ToInt32(filter);
                    var JC = from c in db.JobCodes where c.CodeType == codetype select c;
                    foreach (JobCode code in JC)
                    {
                        ddl = ddl + @"<option value=" + code.CodeID + @">" + code.Code + @"</option>";
                    }
                    break;

                case "EQUIP":
                    List<DRC_CustDevice> dev = new List<DRC_CustDevice>();
                    int acct = Convert.ToInt32(filter);
                    var D = from d in db2.DRC_CustDevices where d.CustID == acct select d;
                    if (D.Count() > 0)
                    {
                        foreach (DRC_CustDevice DEV in D)
                        {
                            ddl = ddl + @"<option value=" + DEV.DeviceID + @">" + DEV.Name + @" sn:" + DEV.SN + @"</option>";
                        }
                    }
                    else
                    {
                        selected = "NEW ENTRY";
                    }
                    break;
                case "EQUIPTYPE":
                    List<DRC_CustomerDeviceType> DT = new List<DRC_CustomerDeviceType>();
                    
                    var DevT = from d in db2.DRC_CustomerDeviceTypes select d;
                    if (DevT.Count() > 0)
                    {
                        foreach (DRC_CustomerDeviceType devt in DevT)
                        {
                            ddl = ddl + @"<option value=" + devt.DeviceTypeID + @">" + devt.DeviceType + @"</option>";
                        }
                    }
                    else
                    {
                        selected = "NEW ENTRY";
                    }
                    break;
            }
            #endregion
            tb = tb + tbval;
            ddl = ddl + @"</select>";

//            string F0 = @" var selval" + name + @"=0; var downarrowpress=false;";
//            if (selected == "") F0 = F0 + @" selval" + name + @"=document.getElementById('ddl" + name + @"').options[1].value;
//            document.getElementById('ddl" + name + @"').options[1].selected=true;
//            $(tb" + name + @").val(document.getElementById('ddl" + name + @"').options[1].text);
//            ";
//            else
//            {

//                F0 = F0 + @"  $(tb" + name + @").val('" + selected + @"');
//                            for (var i=0;i<document.getElementById('ddl" + name + @"').length;i++)
//                            {
//                                if(document.getElementById('ddl" + name + @"').options[i].text=='" + selected + @"')
//                                    {
//                                       selval" + name + @"= document.getElementById('ddl" + name + @"').options[i].value;
//                                       document.getElementById('ddl" + name + @"').options[i].selected=true;
//                                       
//                                    }
//                            } 
//
//";
//            }


//            string F1 = @"var l" + name + @"= 0; var idx" + name + @"=0; $(sddl" + name + @").hide(); var sidx" + name + @"=0; var  ddlval" + name + @"=0;
//              $(tb" + name + @").keyup(function(event)
//                {
//                    l" + name + @"=$(tb" + name + @").val().length;
//               
//
//                    try //error happens when tabbing but does not affect intended proccess so put in try group
//                    {
//                    
//                        if(l" + name + @">0)
//                            {
//                                $(ddl" + name + @").hide();
//                                $(sddl" + name + @").empty();
//                                $(sddl" + name + @").append('<option value=0>NEW ENTRY</option>');
//                                for (var i=1;i<document.getElementById('ddl" + name + @"').length;i++)
//                                    {
//                                        ddlval" + name + @"=document.getElementById('ddl" + name + @"').options[i].value;
//                                        if($(tb" + name + @").val()==document.getElementById('ddl" + name + @"').options[i].text)
//                                            {   
//                                                document.getElementById('ddl" + name + @"').options[i].selected=true;
//                                                selval" + name + @"= document.getElementById('ddl" + name + @"').options[i].value;
//                                            }
//                                        else{
//                                                document.getElementById('ddl" + name + @"').selectedIndex=-1;
//                                                selval" + name + @"=0;
//                                            }
//                        
//";

//            switch (autotype)
//            {
//                case 0:
//                    F1 = F1 + @"
//                                        
//                            
//                                        if(document.getElementById('ddl" + name + @"').options[i].text.substr(0,l" + name + @").toUpperCase()==$(tb" + name + @").val().toUpperCase())
//                                            {
//                                    
//                                    
//                                                $(sddl" + name + @").append('<option value='+ddlval" + name + @"+'>'+document.getElementById('ddl" + name + @"').options[i].text+'</option>');
//                                                sidx" + name + @"++;
//                                            }
//
//                                        
//";


//                    break;
//                case 1:

//                    F1 = F1 + @"
//                                        if(document.getElementById('ddl" + name + @"').options[i].text.toUpperCase().lastIndexOf($(tb" + name + @").val().toUpperCase())>-1)
//                                            {
//                                    
//                                                $(sddl" + name + @").show();
//                                                $(sddl" + name + @").append('<option value='+ddlval" + name + @"+'>'+document.getElementById('ddl" + name + @"').options[i].text+'</option>');
//                                                sidx" + name + @"++;
//                                            
//}";

//                    break;

//                default:
//                    break;
//            }


//            F1 = F1 + @"
//                                        }//This is the end of the for loop
//                               var sddlLENGTH=document.getElementById('sddl" + name + @"').length;
//                                document.getElementById('sddl" + name + @"').selectedIndex=0;
//                                if (sddlLENGTH>0)
//                                            {
//                                                $(ddl" + name + @").hide();
//                                                $(sddl" + name + @").show();
//                                                if(event.keyCode==40)
//                                                {(sddl" + name + @").focus(); downarrowpress=true;}
//                                                else
//                                                {downarrowpress=false;}
//                                                if(sddlLENGTH<" + subsize + @")
//                                                    {
//                                                        $(sddl" + name + @").attr('size',sddlLENGTH);
//                                                    }
//                                                    else
//                                                    {
//                                                        $(sddl" + name + @").attr('size','" + subsize + @"');
//                                                    }
//                                            }
//                                        else
//                                            {
//                                                $(ddl" + name + @").show();
//                                                $(sddl" + name + @").hide();
//                                                
//                                            }
//                                
//                            }
//                        else
//                            {
//                            
//                                $(ddl" + name + @").show();
//                                $(sddl" + name + @").hide();
//                            }
//                        P=$(tb" + name + @").position();
//                        $(sddl" + name + @").css('left',P.left); $(sddl" + name + @").css('top',(P.top+$(tb" + name + @").height()+5)); $(ddl" + name + @").css('left',P.left); $(ddl" + name + @").css('top',(P.top+$(tb" + name + @").height()+5));
//                    }
//                 catch(err)
//                    {
//                    }   
//            
//
//
//
//
//});";
//            string F2 = @"  $(ddl" + name + @").change(function(event){$(tb" + name + @").val(document.getElementById('ddl" + name + @"').options[document.getElementById('ddl" + name + @"').selectedIndex].text); selval" + name + @"=document.getElementById('ddl" + name + @"').options[document.getElementById('ddl" + name + @"').selectedIndex].value; $(ddl" + name + @").hide(); 
////showDetailsButton('" + name + @"');
//});";
//            string F3 = @" $(sddl" + name + @").change(function(event){$(tb" + name + @").val(document.getElementById('sddl" + name + @"').options[document.getElementById('sddl" + name + @"').selectedIndex].text); selval" + name + @"=document.getElementById('sddl" + name + @"').options[document.getElementById('sddl" + name + @"').selectedIndex].value; 
//
////showDetailsButton('" + name + @"');  
//$(sddl" + name + @").hide();}); ";
//            string F4 = @" function " + name + @"selmouseover(selectedidx)
//                          {
//                            
//                            alert(selectedidx);
//                          }
//                        function " + name + @"selmouseout(selectedidx)
//                          {
//                            alert(selectedidx);
//                          }
//
//
//            ";
//            string F5 = @" $(tb" + name + @").blur(function(){}); 
//
//";//for testing whether part of list and getting option to add.

//            string result = @" $(" + div + @").append('" + ddl + tb + @"'); " + Lists + F0 + F1 + F2 + F3 + F4 + F5;

//            //final ddl and sddl presentation handling
//            result = result + @" $(ddl" + name + @").hide();  ";
//            string docreadyfunction = @"$(document).ready(function(){P=$(tb" + name + @").position();    $(sddl" + name + @").css('position','absolute');  $(sddl" + name + @").css('z-index','20'); $(ddl" + name + @").css('position','absolute'); $(ddl" + name + @").css('z-index','20'); $(tb" + name + @").blur(function(){if(!(downarrowpress)){$(sddl" + name + @").hide();}});
//
//}); ";

            //            if (ddlclass == "offset")//temp fix where some divs need adjustment of position relationships to parent
            //            {
            //                docreadyfunction = docreadyfunction + @"  $(sddl" + name + @").css('left',(P.left+$(" + div + @").position().left)); $(sddl" + name + @").css('top',(P.top+($(" + div + @").position().top)+$(tb" + name + @").height()+5)); $(ddl" + name + @").css('left',(P.left+$(" + div + @").position().left)); $(ddl" + name + @").css('top',(P.top+($(" + div + @").position().top)+$(tb" + name + @").height()+5));
            //
            //
            //
            //});";
            //            }
            //            else
            //            {
            //                docreadyfunction = docreadyfunction + @"  $(sddl" + name + @").css('left',P.left); $(sddl" + name + @").css('top',(P.top+$(tb" + name + @").height()+5)); $(ddl" + name + @").css('left',P.left); $(ddl" + name + @").css('top',(P.top+$(tb" + name + @").height()+5));
            //
            //             
            //
            //});";
            //            }
            return ddl;// result + docreadyfunction;
        }
        public string makeGroupedddlInputPair(string div, string name, string title, string lbltext, string selected, string postype,string type, string filter)
        {
            DRCMethods DRCM = new DRCMethods();
            string tbval = ">";
            string thelabel = @"<label id=lblddl" + name + @" style=position:"+postype+@";display:block>" + lbltext + @"</label>";

            string ddl = @"<select style=position:" + postype + @":fixed;display:block id=ddl" + name + @">";

            string tb = @"<input type=text style=position:" + postype + @";display:block id=tb" + name + @" ";

            switch (type)
            {
                case "STKBIN":
                    List<DRC_ItemBin> Bin = DRCrepos.getItemBins(Convert.ToInt32(filter));
                    foreach (DRC_ItemBin B in Bin)
                    {
                        ddl = ddl + @"<option value=" + B.BinID + @">" + B.Name + @"</option>";
                    }
                    if (Bin.Count > 0) tbval = @"value=" + Bin[0].Name + tbval;
                    break;
                case "STKBUILDING":
                    List<DRC_ItemBuilding> Bldg = DRCrepos.getItemBuildings(Convert.ToInt32(filter));
                    foreach (DRC_ItemBuilding B in Bldg)
                    {
                        ddl = ddl + @"<option value=" + B.BuildingID + @">" + B.Name + @"</option>";
                    }
                    if (Bldg.Count > 0) tbval = @"value=" + Bldg[0].Name + tbval;
                    break;
                case "STKROOM":
                    List<DRC_ItemRoom> Room = DRCrepos.getItemRooms(Convert.ToInt32(filter));
                    foreach (DRC_ItemRoom R in Room)
                    {
                        ddl = ddl + @"<option value=" + R.RoomID + @">" + R.Name + @"</option>";
                    }
                    if (Room.Count > 0) tbval = @"value=" + Room[0].Name + tbval;
                    break;
                case "ACCOUNTS":
                    List<Account> al = DRCrepos.AccountList(Convert.ToInt32(filter));

                    foreach (var a in al)
                    {
                        ddl = ddl + @"<option value=" + a.AccountID + @">" + a.Name + @"</option>";
                    }
                    if (al.Count > 0) tbval = @"value=" + al[0].Name + tbval;
                    break;
                case "STATELIST":
                    List<DRC_StateProvenceList> States = DRCrepos.getStates();
                    foreach (DRC_StateProvenceList ST in States)
                    {
                        ddl = ddl + @"<option value=" + ST.StateID + @">" + DRCM.fixstring(ST.StateName) + @"</option>";
                        
                    }
                    if (States.Count > 0) tbval = @"value=" + DRCM.fixstring(States[0].StateName) + tbval;
                    break;
                case "TERMSLIST":
                    List<DRC_Term> Terms = DRCrepos.getTerms();
                    foreach (DRC_Term T in Terms)
                    {
                        ddl = ddl + @"<option value=" + T.TermsID + @">" + DRCM.fixstring(T.TermsDescription) + @"</option>";
                    }
                    if (Terms.Count > 0) tbval = @"value=" + DRCM.fixstring(Terms[0].TermsDescription) + tbval;
                    break;
            }
            tb = tb + tbval;
            ddl = ddl + @"</select>";

            string F0 = @"var selval" + name + @"=0; ";
            if (selected == "") F0 = F0+@" selval" + name + @"=document.getElementById('ddl" + name + @"').options[0].value; ";
            else
            {
                F0 =F0+ @" for (var i=0;i<document.getElementById('ddl" + name + @"').length;i++)
                            {
                                if(document.getElementById('ddl" + name + @"').options[i].text=='" + selected + @"')
                                    {
                                       selval" + name + @"= document.getElementById('ddl" + name + @"').options[i].value;
                                       document.getElementById('ddl" + name + @"').options[i].selected=true;
                                       $(tb" + name + @").val('"+selected+@"');
                                    }
                            } 

";
            }


            string F1 = @"var l" + name + @"= 0; var idx" + name + @"=0; 
              $(tb" + name + @").keyup(function(event)
                {
                
                l" + name + @"=$(tb" + name + @").val().length;
                //hideDetailsButton('" + name + @"');//Function must be in startup, but only used in inventory.
                
                try //error happens when tabbing but does not affect intended proccess so put in try group
                {
                    if(l" + name + @">0)
                    {
                        for (var i=0;i<document.getElementById('ddl" + name + @"').length;i++)
                            {
                               if(document.getElementById('ddl" + name + @"').options[i].text.substr(0,l" + name + @")==$(tb" + name + @").val())
                                {
                                    
                                    document.getElementById('ddl" + name + @"').options[i].style.backgroundColor='#00FF00';
                                    if(document.getElementById('ddl" + name + @"').options[i].text.length==$(tb" + name + @").val().length)
                                    {    
                                        idx" + name + @"=i;
                                        document.getElementById('ddl" + name + @"').selectedIndex=i;
                                        selval" + name + @"=$(':selected').val();
                                        $('option').css('background-Color','white');
                                        document.getElementById('ddl" + name + @"').options[i].style.backgroundColor='#00FF00';
                                       // showDetailsButton('" + name + @"');
                                        break;
                                    }
                                    
                                }
                            else{
                                    document.getElementById('ddl" + name + @"').options[i].style.backgroundColor='white';
                                    selval" + name + @"=0;
                                }
                            }
                    }
                    else{document.getElementById('ddl" + name + @"').options[idx" + name + @"].style.backgroundColor='white';}
                 }
                 catch(err)
                 {
                    
                 }   
            
                    



});";
            string F2 = @"  $(ddl" + name + @").change(function(event){$(tb" + name + @").val(document.getElementById('ddl" + name + @"').options[document.getElementById('ddl" + name + @"').selectedIndex].text); selval" + name + @"=document.getElementById('ddl" + name + @"').options[document.getElementById('ddl" + name + @"').selectedIndex].value; 
//showDetailsButton('" + name + @"');
});";

            string result = @" $(" + div + @").append('" + thelabel + ddl + tb + @"'); " + F0 + F1 + F2;
            return result;
        }
        public string makeddl(string type, string selected, string name,string div, int h, int w, int top, int left)
        {
            
            string filter = "";
            string result;
            if (name.IndexOf(':') > -1)
            {
                int idx = name.IndexOf(':');
                result = @"$("+div+@").append('<select id=" + name.Substring(0, idx) + @"  style=position:fixed;display:block;height:"+h+@"px;width:"+w+@"px;top:" + top + @"px;left:" + left + @"px >";
                filter = name.Substring(idx + 1);
            }
            else
            {
                result = @"$(" + div + @").append('<select id=" + name + @" style=position:fixed;display:block;height:" + h + @"px;width:" + w + @"px;top:" + top + @"px;left:" + left + @"px>";
            }
            if (div == "")//its inline to an existing append so bypass append syntax
            {
                result = "<select id=" + name + @"  style=display:block;height:" + h + @"px;width:" + w +@"px > ";
            }
            bool match = false;

            switch (type)
            {
                case "PRIORITY":
                    var pri =
                                    from p in db.JobCodes
                                    where p.CodeType == 3
                                    select p;
                    foreach (var pr in pri)
                    {
                        if (selected == pr.CodeID.ToString()) result = result + @"<option selected=selected value=" + pr.CodeID + @">" + pr.Code + @"</option>";
                        else result = result + @"<option value=" + pr.CodeID + @">" + pr.Code + @"</option>";
                    }
                    break;
                case "STATUS":
                    var sta =
                                    from s in db.JobCodes
                                    where s.CodeType == 1
                                    select s;
                    foreach (var st in sta)
                    {
                        if (selected == st.CodeID.ToString()) result = result + @"<option selected=selected value=" + st.CodeID + @">" + st.Code + @"</option>";
                        else result = result + @"<option value=" + st.CodeID + @">" + st.Code + @"</option>";
                    }

                    break;
                case "CSR":
                    var csr =
                                    from s in db.JobCodes
                                    where s.CodeType == 5
                                    select s;
                    foreach (var cs in csr)
                    {
                        if (selected == cs.CodeID.ToString()) result = result + @"<option selected=selected value=" + cs.CodeID + @">" + cs.Code + @"</option>";
                        else result = result + @"<option value=" + cs.CodeID + @">" + cs.Code + @"</option>";
                    }

                    break;
                case "CONTACTS":
                    int CI = Convert.ToInt32(filter);
                    var con =
                                    from c in db.DRC_Contacts
                                    where c.AccountID == CI
                                    select c;
                    foreach (var co in con)
                    {
                        if (selected == co.ContactID.ToString())
                        {
                            result = result + @"<option selected=selected value=" + co.ContactID + @">" + co.FirstName + @" " + co.LastName + @" Mbl:" + co.MobilePhone1 + @"</option>";
                            match = true;
                        }
                        else
                        {
                            result = result + @"<option value=" + co.ContactID + @">" + co.FirstName + @" " + co.LastName + @" Mbl:" + co.MobilePhone1 + @"</option>";
                        }
                    }
                    if (!(match)) result = result + @"<option selected=selected value=0>UNKNOWN</option>";

                    break;
                case "SERVICES":
                    var serv =
                                    from se in db.JobCodes
                                    where se.CodeType == 6
                                    select se;
                    foreach (var sv in serv)
                    {
                        if (selected == sv.CodeID.ToString()) result = result + @"<option selected=selected value=" + sv.CodeID + @">" + sv.Code + @"</option>";
                        else result = result + @"<option value=" + sv.CodeID + @">" + sv.Code + @"</option>";
                    }

                    break;
                case "ACCOUNTS":
                    List<Account> al = DRCrepos.AccountList(Convert.ToInt32(selected));

                    foreach (var a in al)
                    {
                        result = result + @"<option value=" + a.AccountID + @">" + a.Name + @"</option>";
                    }
                    break;
                case "TWOACCOUNTS":
                    DRCMethods DM = new DRCMethods();
                    List<string> selections = DM.MakeStringList(selected, '♫');
                    List<Account> twoal = DRCrepos.AccountList(Convert.ToInt32(selections[0]), Convert.ToInt32(selections[1]));
                    foreach (var a in twoal)
                    {
                        result = result + @"<option value=" + a.AccountID + @"♫" + a.AccountType + @">" + a.Name + @"</option>";
                    }
                    break;

                case "PARTTYPE":
                    DRCMethods Dmeth = new DRCMethods();
                    List<DRC_PNCode> PNtype = DRCrepos.getPNCodes();
                    foreach (DRC_PNCode PN in PNtype)
                    {
                        result = result + @"<option value=" + PN.Code + @">" + Dmeth.fixstring(PN.ProductType) + @"</option>";
                    }
                    break;
            }

            if (div == "")//its inline to an existing append so bypass append syntax
            {
                result = result + @"</select>";
            }
            else
            {
                result = result + @"</select>');";
            }
            return result;
        }
        public string makeddl(string type, string selected, string name, string div,string lbl, int h, int w, int top, int left)
        {
            
            string filter = "";
            string result;
            if (name.IndexOf(':') > -1)
            {
                int idx = name.IndexOf(':');
                result = @"$(" + div + @").append('<label style=position:fixed;display:block;height:" + h + @"px;width:" + w + @"px;top:" + (top-h) + @"px;left:" + left + @"px>" + lbl + @"</label><select id=" + name.Substring(0, idx) + @"  style=position:fixed;display:block;height:" + h + @"px;width:" + w + @"px;top:" + top + @"px;left:" + left + @"px >";
                filter = name.Substring(idx + 1);
            }
            else
            {
                result = @"$(" + div + @").append('<label style=position:fixed;display:block;height:" + h + @"px;width:" + w + @"px;top:" + (top - h - 2) + @"px;left:" + left + @"px>" + lbl + @"</label><select id=" + name + @" style=position:fixed;display:block;height:" + h + @"px;width:" + w + @"px;top:" + top + @"px;left:" + left + @"px>";
            }
            bool match = false;

            switch (type)
            {
                case "PRIORITY":
                    var pri =
                                    from p in db.JobCodes
                                    where p.CodeType == 3
                                    select p;
                    foreach (var pr in pri)
                    {
                        if (selected == pr.CodeID.ToString()) result = result + @"<option selected=selected value=" + pr.CodeID + @">" + pr.Code + @"</option>";
                        else result = result + @"<option value=" + pr.CodeID + @">" + pr.Code + @"</option>";
                    }
                    break;
                case "STATUS":
                    var sta =
                                    from s in db.JobCodes
                                    where s.CodeType == 1
                                    select s;
                    foreach (var st in sta)
                    {
                        if (selected == st.CodeID.ToString()) result = result + @"<option selected=selected value=" + st.CodeID + @">" + st.Code + @"</option>";
                        else result = result + @"<option value=" + st.CodeID + @">" + st.Code + @"</option>";
                    }

                    break;
                case "CSR":
                    var csr =
                                    from s in db.JobCodes
                                    where s.CodeType == 5
                                    select s;
                    foreach (var cs in csr)
                    {
                        if (selected == cs.CodeID.ToString()) result = result + @"<option selected=selected value=" + cs.CodeID + @">" + cs.Code + @"</option>";
                        else result = result + @"<option value=" + cs.CodeID + @">" + cs.Code + @"</option>";
                    }

                    break;
                case "CONTACTS":
                    int CI = Convert.ToInt32(filter);
                    var con =
                                    from c in db.DRC_Contacts
                                    where c.AccountID == CI
                                    select c;
                    foreach (var co in con)
                    {
                        if (selected == co.ContactID.ToString())
                        {
                            result = result + @"<option selected=selected value=" + co.ContactID + @">" + co.FirstName + @" " + co.LastName + @" Mbl:" + co.MobilePhone1 + @"</option>";
                            match = true;
                        }
                        else
                        {
                            result = result + @"<option value=" + co.ContactID + @">" + co.FirstName + @" " + co.LastName + @" Mbl:" + co.MobilePhone1 + @"</option>";
                        }
                    }
                    if (!(match)) result = result + @"<option selected=selected value=0>UNKNOWN</option>";

                    break;
                case "SERVICES":
                    var serv =
                                    from se in db.JobCodes
                                    where se.CodeType == 6
                                    select se;
                    foreach (var sv in serv)
                    {
                        if (selected == sv.CodeID.ToString()) result = result + @"<option selected=selected value=" + sv.CodeID + @">" + sv.Code + @"</option>";
                        else result = result + @"<option value=" + sv.CodeID + @">" + sv.Code + @"</option>";
                    }

                    break;
                case "ACCOUNTS":
                    List<Account> al = DRCrepos.AccountList(Convert.ToInt32(selected));
                    foreach (var a in al)
                    {
                        result = result + @"<option value=" + a.AccountID + @">" + a.Name + @"</option>";
                    }
                    break;
                case "TWOACCOUNTS":
                    DRCMethods DM = new DRCMethods();
                    List<string> selections = DM.MakeStringList(selected, '♫');
                    List<Account> twoal = DRCrepos.AccountList(Convert.ToInt32(selections[0]), Convert.ToInt32(selections[1]));
                    foreach (var a in twoal)
                    {
                        result = result + @"<option value=" + a.AccountID + @"♫" + a.AccountType + @">" + a.Name + @"</option>";
                    }
                    break;
                case "PARTTYPE":
                    DRCMethods Dmeth = new DRCMethods();
                    List<DRC_PNCode> PNtype = DRCrepos.getPNCodes();
                    foreach (DRC_PNCode PN in PNtype)
                    {
                        result = result + @"<option value=" + PN.Code + @">" + Dmeth.fixstring(PN.ProductType) + @"</option>";
                    }

                    break;
            }


            result = result + @"</select>');";
            return result;
        }
        public string makeddl(string ddlclass,string type, string selected, string name, string div)
        {
            string action = "";
            string filter = "";
            string goodname="";
            string result;
            if (name.IndexOf(':') > -1)
            {
                int idx = name.IndexOf(':');
                goodname = name.Substring(0, idx);
                result = @"$(" + div + @").append('<select id=" + goodname + @" class="+ddlclass+@" >";
                action = @" var " + goodname + @"var=''; ";
                filter = name.Substring(idx + 1);//filter is built into name on this one
            }
            else
            {
                goodname = name;
                result = @"$(" + div + @").append('<select id=" + goodname + @" class="+ddlclass+@">";
                action = @" var " + goodname + @"var=''; ";
            }
            if (div == "")//its inline to an existing append so bypass append syntax
            {
                result = "<select id=" + name + @"  class="+ddlclass+@"> ";
            }
            bool match = false;

            switch (type)
            {
                case "PRIORITY":
                    var pri =
                                    from p in db.JobCodes
                                    where p.CodeType == 3
                                    select p;
                    action = action + @" " + goodname + @"var=" + pri.First().CodeID + @"; ";
                    foreach (var pr in pri)
                    {
                        if (selected == pr.CodeID.ToString())
                        {
                            result = result + @"<option selected=selected value=" + pr.CodeID + @">" + pr.Code + @"</option>";
                            action = action + @" " + goodname + @"var=" + pr.CodeID + @"; ";
                        }
                        else
                        {
                            result = result + @"<option value=" + pr.CodeID + @">" + pr.Code + @"</option>";
                            
                        }
                    }
                    break;
                case "STATUS":
                    var sta =
                                    from s in db.JobCodes
                                    where s.CodeType == 1
                                    select s;
                    foreach (var st in sta)
                    {
                        if (selected == st.CodeID.ToString()) result = result + @"<option selected=selected value=" + st.CodeID + @">" + st.Code + @"</option>";
                        else result = result + @"<option value=" + st.CodeID + @">" + st.Code + @"</option>";
                    }

                    break;
                case "CSR":
                    var csr =
                                    from s in db.JobCodes
                                    where s.CodeType == 5
                                    select s;
                    action = action + @" " + goodname + @"var=" + csr.First().CodeID + @"; ";
                    foreach (var cs in csr)
                    {
                        if (selected == cs.CodeID.ToString())
                        {
                            result = result + @"<option selected=selected value=" + cs.CodeID + @">" + cs.Code + @"</option>";
                            action = action + @" " + goodname + @"var=" + cs.CodeID + @"; ";
                        }
                        else result = result + @"<option value=" + cs.CodeID + @">" + cs.Code + @"</option>";
                    }

                    break;
                case "CONTACTS":
                    int CI = Convert.ToInt32(filter);
                    var con =
                                    from c in db.DRC_Contacts
                                    where c.AccountID == CI
                                    select c;
                    foreach (var co in con)
                    {
                        if (selected == co.ContactID.ToString())
                        {
                            result = result + @"<option selected=selected value=" + co.ContactID + @">" + co.FirstName + @" " + co.LastName + @" Mbl:" + co.MobilePhone1 + @"</option>";
                            match = true;
                        }
                        else
                        {
                            result = result + @"<option value=" + co.ContactID + @">" + co.FirstName + @" " + co.LastName + @" Mbl:" + co.MobilePhone1 + @"</option>";
                        }
                    }
                    if (!(match)) result = result + @"<option selected=selected value=0>UNKNOWN</option>";

                    break;
                case "SERVICES":
                    var serv =
                                    from se in db.JobCodes
                                    where se.CodeType == 6
                                    select se;
                    foreach (var sv in serv)
                    {
                        if (selected == sv.CodeID.ToString()) result = result + @"<option selected=selected value=" + sv.CodeID + @">" + sv.Code + @"</option>";
                        else result = result + @"<option value=" + sv.CodeID + @">" + sv.Code + @"</option>";
                    }

                    break;
                case "ACCOUNTS":
                    List<Account> al = DRCrepos.AccountList(Convert.ToInt32(selected));

                    foreach (var a in al)
                    {
                        result = result + @"<option value=" + a.AccountID + @">" + a.Name + @"</option>";
                    }
                    break;
                case "TWOACCOUNTS":
                    DRCMethods DM = new DRCMethods();
                    List<string> selections = DM.MakeStringList(selected, '♫');
                    List<Account> twoal = DRCrepos.AccountList(Convert.ToInt32(selections[0]), Convert.ToInt32(selections[1]));
                    foreach (var a in twoal)
                    {
                        result = result + @"<option value=" + a.AccountID + @"♫" + a.AccountType + @">" + a.Name + @"</option>";
                    }
                    break;

                case "PARTTYPE":
                    DRCMethods Dmeth = new DRCMethods();
                    List<DRC_PNCode> PNtype = DRCrepos.getPNCodes();
                    foreach (DRC_PNCode PN in PNtype)
                    {
                        result = result + @"<option value=" + PN.Code + @">" + Dmeth.fixstring(PN.ProductType) + @"</option>";
                    }
                    break;

                case "JOBCODE"://Filter for job code type
                    List<JobCode> codes = new List<JobCode>();
                    int codetype = Convert.ToInt32(filter);
                    var JC = from c in db.JobCodes where c.CodeType == codetype select c;
                    foreach (JobCode code in JC)
                    {
                        result = result + @"<option value=" + code.CodeID + @">" + code.Code + @"</option>";
                    }
                    break;
            }

            if (div == "")//its inline to an existing append so bypass append syntax
            {
                result = result + @"</select> ";
            }
            else
            {
                result = result + @"</select>'); ";
            }
            
            action = action + @" $(" + goodname + @").change(function(){" + goodname + @"var=document.getElementById('" + goodname + @"').options[document.getElementById('" + goodname + @"').selectedIndex].value;}); ";
            result = result + action;
            
            return result;// +action;
        }
        public string MakeDropDown(string div,string name,string ddlclass,string tbclass, string type, string selected,string filter  )
        {
            string action = "";
            
            string result;
            
                result = @"$(" + div + @").append('<select id=" + name + @" class=" + ddlclass + @">";
                action = @" var " + name + @"var=''; ";
            
            if (div == "")//its inline to an existing append so bypass append syntax
            {
                result = "<select id=" + name + @"  class=" + ddlclass + @"> ";
            }
            bool match = false;

            switch (type)
            {
                case "PRIORITY":
                    var pri =
                                    from p in db.JobCodes
                                    where p.CodeType == 3
                                    select p;
                    action = action + @" " + name + @"var=" + pri.First().CodeID + @"; ";
                    foreach (var pr in pri)
                    {
                        if (selected == pr.CodeID.ToString())
                        {
                            result = result + @"<option selected=selected value=" + pr.CodeID + @">" + pr.Code + @"</option>";
                            action = action + @" " + name + @"var=" + pr.CodeID + @"; ";
                        }
                        else
                        {
                            result = result + @"<option value=" + pr.CodeID + @">" + pr.Code + @"</option>";

                        }
                    }
                    break;
                case "STATUS":
                    var sta =
                                    from s in db.JobCodes
                                    where s.CodeType == 1
                                    select s;
                    foreach (var st in sta)
                    {
                        if (selected == st.CodeID.ToString()) result = result + @"<option selected=selected value=" + st.CodeID + @">" + st.Code + @"</option>";
                        else result = result + @"<option value=" + st.CodeID + @">" + st.Code + @"</option>";
                    }

                    break;
                case "CSR":
                    var csr =
                                    from s in db.JobCodes
                                    where s.CodeType == 5
                                    select s;
                    action = action + @" " + name + @"var=" + csr.First().CodeID + @"; ";
                    foreach (var cs in csr)
                    {
                        if (selected == cs.CodeID.ToString())
                        {
                            result = result + @"<option selected=selected value=" + cs.CodeID + @">" + cs.Code + @"</option>";
                            action = action + @" " + name + @"var=" + cs.CodeID + @"; ";
                        }
                        else result = result + @"<option value=" + cs.CodeID + @">" + cs.Code + @"</option>";
                    }

                    break;
                case "CONTACTS":
                    int CI = Convert.ToInt32(filter);
                    var con =
                                    from c in db.DRC_Contacts
                                    where c.AccountID == CI
                                    select c;
                    foreach (var co in con)
                    {
                        if (selected == co.ContactID.ToString())
                        {
                            result = result + @"<option selected=selected value=" + co.ContactID + @">" + co.FirstName + @" " + co.LastName + @" Mbl:" + co.MobilePhone1 + @"</option>";
                            match = true;
                        }
                        else
                        {
                            result = result + @"<option value=" + co.ContactID + @">" + co.FirstName + @" " + co.LastName + @" Mbl:" + co.MobilePhone1 + @"</option>";
                        }
                    }
                    if (!(match)) result = result + @"<option selected=selected value=0>UNKNOWN</option>";

                    break;
                case "SERVICES":
                    var serv =
                                    from se in db.JobCodes
                                    where se.CodeType == 6
                                    select se;
                    foreach (var sv in serv)
                    {
                        if (selected == sv.CodeID.ToString()) result = result + @"<option selected=selected value=" + sv.CodeID + @">" + sv.Code + @"</option>";
                        else result = result + @"<option value=" + sv.CodeID + @">" + sv.Code + @"</option>";
                    }

                    break;
                case "ACCOUNTS":
                    List<Account> al = DRCrepos.AccountList(Convert.ToInt32(selected));

                    foreach (var a in al)
                    {
                        result = result + @"<option value=" + a.AccountID + @">" + a.Name + @"</option>";
                    }
                    break;
                case "TWOACCOUNTS":
                    DRCMethods DM = new DRCMethods();
                    List<string> selections = DM.MakeStringList(selected, '♫');
                    List<Account> twoal = DRCrepos.AccountList(Convert.ToInt32(selections[0]), Convert.ToInt32(selections[1]));
                    foreach (var a in twoal)
                    {
                        result = result + @"<option value=" + a.AccountID + @"♫" + a.AccountType + @">" + a.Name + @"</option>";
                    }
                    break;

                case "PARTTYPE":
                    DRCMethods Dmeth = new DRCMethods();
                    List<DRC_PNCode> PNtype = DRCrepos.getPNCodes();
                    foreach (DRC_PNCode PN in PNtype)
                    {
                        result = result + @"<option value=" + PN.Code + @">" + Dmeth.fixstring(PN.ProductType) + @"</option>";
                    }
                    break;

                case "JOBCODE"://Filter for job code type
                    List<JobCode> codes = new List<JobCode>();
                    int codetype = Convert.ToInt32(filter);
                    var JC = from c in db.JobCodes where c.CodeType == codetype select c;
                    foreach (JobCode code in JC)
                    {
                        if (selected == code.CodeID.ToString()) result = result + @"<option selected=selected value=" + code.CodeID + @">" + code.Code + @"</option>";
                        else
                        result = result + @"<option value=" + code.CodeID + @">" + code.Code + @"</option>";
                    }
                    break;
            }

            if (div == "")//its inline to an existing append so bypass append syntax
            {
                result = result + @"</select> ";
            }
            else
            {
                result = result + @"</select>'); ";
            }

            action = action + @" $(" + name + @").change(function(){" + name + @"var=document.getElementById('" + name + @"').options[document.getElementById('" + name + @"').selectedIndex].value;}); ";
            result = result + action;

            return result;// +action;
        }
        public string makeautoddl(string type, string selected, string filter, string name, string div, string lbl, int h, int w, int top, int left,int fntsz)
        {
            DRCMethods DRCM = new DRCMethods();
            //string filter = "";
            string result;
            //if (name.IndexOf(':') > -1)
            //{
            //    int idx = name.IndexOf(':');
            //    result = @"$(" + div + @").append('<select id=" + name.Substring(0, idx) + @"  style=position:fixed;display:block;height:" + h + @"px;width:" + w + @"px;top:" + top + @"px;left:" + left + @"px >";
            //    filter = name.Substring(idx + 1);
            //}
            //else
            //{
                result = @"$(" + div + @").append('<label id=lbl"+name+@" style=position:fixed;display:block;font-size:" + fntsz + @"px;height:" + h + @"px;width:" + w + @"px;top:" + (top - h - 7) + @"px;left:" + left + @"px>" + lbl + @"</label><div id=div" + name + @" style=position:fixed;font-size:" + (fntsz-4) + @"px;display:block;height:" + h + @"px;width:" + w + @"px;top:" + (top - 7) + @"px;left:" + left + @"px><select id=" + name + @"  >";
           // }
            bool match = false;

            switch (type)
            {
                case "PRIORITY":
                    var pri =
                                    from p in db.JobCodes
                                    where p.CodeType == 3
                                    select p;
                    foreach (var pr in pri)
                    {
                        if (selected == pr.CodeID.ToString()) result = result + @"<option selected=selected value=" + pr.CodeID + @">" + pr.Code + @"</option>";
                        else result = result + @"<option value=" + pr.CodeID + @">" + pr.Code + @"</option>";
                    }
                    break;
                case "STATUS":
                    var sta =
                                    from s in db.JobCodes
                                    where s.CodeType == 1
                                    select s;
                    foreach (var st in sta)
                    {
                        if (selected == st.CodeID.ToString()) result = result + @"<option selected=selected value=" + st.CodeID + @">" + st.Code + @"</option>";
                        else result = result + @"<option value=" + st.CodeID + @">" + st.Code + @"</option>";
                    }

                    break;
                case "CSR":
                    var csr =
                                    from s in db.JobCodes
                                    where s.CodeType == 5
                                    select s;
                    foreach (var cs in csr)
                    {
                        if (selected == cs.CodeID.ToString()) result = result + @"<option selected=selected value=" + cs.CodeID + @">" + cs.Code + @"</option>";
                        else result = result + @"<option value=" + cs.CodeID + @">" + cs.Code + @"</option>";
                    }

                    break;
                case "CONTACTS":
                    int CI = Convert.ToInt32(filter);
                    var con =
                                    from c in db.DRC_Contacts
                                    where c.AccountID == CI
                                    select c;
                    foreach (var co in con)
                    {
                        if (selected == co.ContactID.ToString())
                        {
                            result = result + @"<option selected=selected value=" + co.ContactID + @">" + co.FirstName + @" " + co.LastName + @" Mbl:" + co.MobilePhone1 + @"</option>";
                            match = true;
                        }
                        else
                        {
                            result = result + @"<option value=" + co.ContactID + @">" + co.FirstName + @" " + co.LastName + @" Mbl:" + co.MobilePhone1 + @"</option>";
                        }
                    }
                    if (!(match)) result = result + @"<option selected=selected value=0>UNKNOWN</option>";

                    break;
                case "SERVICES":
                    var serv =
                                    from se in db.JobCodes
                                    where se.CodeType == 6
                                    select se;
                    foreach (var sv in serv)
                    {
                        if (selected == sv.CodeID.ToString()) result = result + @"<option selected=selected value=" + sv.CodeID + @">" + sv.Code + @"</option>";
                        else result = result + @"<option value=" + sv.CodeID + @">" + sv.Code + @"</option>";
                    }

                    break;
                case "ACCOUNTS":
                    List<Account> al = DRCrepos.AccountList(Convert.ToInt32(filter));
                    foreach (var a in al)
                    {
                        result = result + @"<option value=" + a.AccountID + @">" + a.Name + @"</option>";
                    }
                    break;
                case "TWOACCOUNTS":
                    DRCMethods DM = new DRCMethods();
                    List<string> selections = DM.MakeStringList(selected, '♫');
                    List<Account> twoal = DRCrepos.AccountList(Convert.ToInt32(selections[0]), Convert.ToInt32(selections[1]));
                    foreach (var a in twoal)
                    {
                        result = result + @"<option value=" + a.AccountID + @"♫" + a.AccountType + @">" + a.Name + @"</option>";
                    }
                    break;
                case "PARTTYPE":
                    List<DRC_PNCode> PNtype = DRCrepos.getPNCodes();
                    foreach (DRC_PNCode PN in PNtype)
                    {
                        result = result + @"<option value=" + PN.Code + @">" + DRCM.fixstring(PN.ProductType) + @"</option>";
                    }

                    break;
                case "PARTMAN":
                    List<DRC_ManCode> Man = DRCrepos.getManCodes();
                    foreach (DRC_ManCode M in Man)
                    {
                        result = result + @"<option value=" + M.Code + @">" + DRCM.fixstring(M.Manufacturer) + @"</option>";
                    }
                    break;
                case "CUSTTERMS":
                    List<DRC_Term> CustTerms = DRCrepos.getTerms();
                    foreach (DRC_Term CT in CustTerms)
                    {
                        result = result + @"<option value=" + CT.TermsID + @">" + DRCM.fixstring(CT.TermsDescription) + @"</option>";
                    }
                    break;
                case "STATELIST":
                    List<DRC_StateProvenceList> States = DRCrepos.getStates();
                    foreach (DRC_StateProvenceList ST in States)
                    {
                        result = result + @"<option value=" + ST.StateID + @">" + DRCM.fixstring(ST.StateName) + @"</option>";
                    }
                    break;
                case "TAXCODE":
                    List<DRC_TaxCode> Tax = DRCrepos.getTaxCodes();
                    foreach (DRC_TaxCode T in Tax)
                    {
                        result = result + @"<option value=" + T.TaxCodeID + @">" +T.Name+@"|"+ DRCM.fixstring(T.Description) +@"|"+T.CurrentRate.ToString()+ @"</option>";
                    }
                    break;
                case "STKBIN":
                    List<DRC_ItemBin> Bin = DRCrepos.getItemBins(Convert.ToInt32(filter));
                    foreach (DRC_ItemBin B in Bin)
                    {
                        result = result + @"<option value=" + B.BinID + @">" + B.Name + @"</option>";
                    }
                    break;
                case "STKBUILDING":
                    List<DRC_ItemBuilding> Bldg = DRCrepos.getItemBuildings(Convert.ToInt32(filter));
                    foreach (DRC_ItemBuilding B in Bldg)
                    {
                        result = result + @"<option value=" + B.BuildingID + @">" + B.Name + @"</option>";
                    }
                    break;
                case "STKROOM":
                    List<DRC_ItemRoom> Room = DRCrepos.getItemRooms(Convert.ToInt32(filter));
                    foreach (DRC_ItemRoom R in Room)
                    {
                        result = result + @"<option value=" + R.RoomID + @">" + R.Name + @"</option>";
                    }
                    break;
                
            }

            //complete select and add autolist functionality
            result = result + @"</select></div>'); (function($) {
		$.widget('ui." + name + @"', {
			_create: function() {
				var self = this;
				var select = this.element.hide();
				var input = $('<input>')
					.insertAfter(select)
					.autocomplete({
						source: function(request, response) {
							var matcher = new RegExp(request.term, 'i');
							response(select.children('option').map(function() {
								var text = $(this).text();
                                    
								if (this.value && (!request.term || matcher.test(text)))
									return {
										id: this.value,
										label: text.replace(new RegExp('(?![^&;]+;)(?!<[^<>]*)(' + $.ui.autocomplete.escapeRegex(request.term) + ')(?![^<>]*>)(?![^&;]+;)', 'gi'), '<strong>$1</strong>'),
										value: text
									}
							}));
						},
						delay: 0,
						change: function(event, ui) {
							if (!ui.item) {
								// remove invalid value, as it didn't match anything
								$(this).val('');
                                
								return false;
							}
							select.val(ui.item.id);

							self._trigger('selected', event, {
								item: select.find('[value=' + ui.item.id + ']')
							});
						
						},
						minLength: 0,
                        select: function(event,ui){autoitem" + name + @"(ui.item);


                        selitem"+name+@"=ui.item;

                        sel"+name+@"=ui.item.id;   

                        }
                        
                        
					})
					.addClass('ui-widget ui-widget-content ui-corner-left');

$('<button>&nbsp;</button>')
				.attr('tabIndex', -1)
				.attr('title', 'Show All Items')
				.insertAfter(input)
				.button({
					icons: { 
						primary: 'ui-icon-triangle-1-s'
					},
					text: false
				}).removeClass('ui-corner-all')
				.addClass('ui-corner-right ui-button-icon')
				.click(function() {
					// close if already visible
					if (input.autocomplete('widget').is(':visible')) {
						input.autocomplete('close');
						return;
					}
					// pass empty string as value to search for, displaying all results
					input.autocomplete('search', '');
					input.focus();

				});
			}
		});

	})(jQuery);

		
	$(function() {
		$('#" + name + @"')."+name+@"();
		$('#toggle').click(function() {
			$('#" + name + @"').toggle();
		});
	});";
            result = result + @" var selitem" + name + @"=''; sel" + name + @"=''; function autoitem" + name + @"(data) {selecteditem=data;} ";

            return result;
        }
//        public string makeGroupautoddl(string type, string selected, string filter, string name, string div, string lbl,string postype)
//        {
//            DRCMethods DRCM = new DRCMethods();
//            //string filter = "";
//            string result;
//            //if (name.IndexOf(':') > -1)
//            //{
//            //    int idx = name.IndexOf(':');
//            //    result = @"$(" + div + @").append('<select id=" + name.Substring(0, idx) + @"  style=position:fixed;display:block;height:" + h + @"px;width:" + w + @"px;top:" + top + @"px;left:" + left + @"px >";
//            //    filter = name.Substring(idx + 1);
//            //}
//            //else
//            //{
//            result = @"$(" + div + @").append('<label id=lbl" + name + @" style=position:" + postype + @";display:block>" + lbl + @"</label><div id=div" + name + @" style=position:" + postype + @";display:block><select id=" + name + @"  style=position:" + postype + @";display:block>";
//            // }
//            bool match = false;

//            switch (type)
//            {
//                case "PRIORITY":
//                    var pri =
//                                    from p in db.JobCodes
//                                    where p.CodeType == 3
//                                    select p;
//                    foreach (var pr in pri)
//                    {
//                        if (selected == pr.CodeID.ToString()) result = result + @"<option selected=selected value=" + pr.CodeID + @">" + pr.Code + @"</option>";
//                        else result = result + @"<option value=" + pr.CodeID + @">" + pr.Code + @"</option>";
//                    }
//                    break;
//                case "STATUS":
//                    var sta =
//                                    from s in db.JobCodes
//                                    where s.CodeType == 1
//                                    select s;
//                    foreach (var st in sta)
//                    {
//                        if (selected == st.CodeID.ToString()) result = result + @"<option selected=selected value=" + st.CodeID + @">" + st.Code + @"</option>";
//                        else result = result + @"<option value=" + st.CodeID + @">" + st.Code + @"</option>";
//                    }

//                    break;
//                case "CSR":
//                    var csr =
//                                    from s in db.JobCodes
//                                    where s.CodeType == 5
//                                    select s;
//                    foreach (var cs in csr)
//                    {
//                        if (selected == cs.CodeID.ToString()) result = result + @"<option selected=selected value=" + cs.CodeID + @">" + cs.Code + @"</option>";
//                        else result = result + @"<option value=" + cs.CodeID + @">" + cs.Code + @"</option>";
//                    }

//                    break;
//                case "CONTACTS":
//                    int CI = Convert.ToInt32(filter);
//                    var con =
//                                    from c in db.DRC_Contacts
//                                    where c.AccountID == CI
//                                    select c;
//                    foreach (var co in con)
//                    {
//                        if (selected == co.ContactID.ToString())
//                        {
//                            result = result + @"<option selected=selected value=" + co.ContactID + @">" + co.FirstName + @" " + co.LastName + @" Mbl:" + co.MobilePhone1 + @"</option>";
//                            match = true;
//                        }
//                        else
//                        {
//                            result = result + @"<option value=" + co.ContactID + @">" + co.FirstName + @" " + co.LastName + @" Mbl:" + co.MobilePhone1 + @"</option>";
//                        }
//                    }
//                    if (!(match)) result = result + @"<option selected=selected value=0>UNKNOWN</option>";

//                    break;
//                case "SERVICES":
//                    var serv =
//                                    from se in db.JobCodes
//                                    where se.CodeType == 6
//                                    select se;
//                    foreach (var sv in serv)
//                    {
//                        if (selected == sv.CodeID.ToString()) result = result + @"<option selected=selected value=" + sv.CodeID + @">" + sv.Code + @"</option>";
//                        else result = result + @"<option value=" + sv.CodeID + @">" + sv.Code + @"</option>";
//                    }

//                    break;
//                case "ACCOUNTS":
//                    List<Account> al = DRCrepos.AccountList(Convert.ToInt32(filter));
//                    foreach (var a in al)
//                    {
//                        result = result + @"<option value=" + a.AccountID + @">" + a.Name + @"</option>";
//                    }
//                    break;
//                case "TWOACCOUNTS":
//                    DRCMethods DM = new DRCMethods();
//                    List<string> selections = DM.MakeStringList(selected, '♫');
//                    List<Account> twoal = DRCrepos.AccountList(Convert.ToInt32(selections[0]), Convert.ToInt32(selections[1]));
//                    foreach (var a in twoal)
//                    {
//                        result = result + @"<option value=" + a.AccountID + @"♫" + a.AccountType + @">" + a.Name + @"</option>";
//                    }
//                    break;
//                case "PARTTYPE":
//                    List<DRC_PNCode> PNtype = DRCrepos.getPNCodes();
//                    foreach (DRC_PNCode PN in PNtype)
//                    {
//                        result = result + @"<option value=" + PN.Code + @">" + DRCM.fixstring(PN.ProductType) + @"</option>";
//                    }

//                    break;
//                case "PARTMAN":
//                    List<DRC_ManCode> Man = DRCrepos.getManCodes();
//                    foreach (DRC_ManCode M in Man)
//                    {
//                        result = result + @"<option value=" + M.Code + @">" + DRCM.fixstring(M.Manufacturer) + @"</option>";
//                    }
//                    break;
//                case "CUSTTERMS":
//                    List<DRC_Term> CustTerms = DRCrepos.getTerms();
//                    foreach (DRC_Term CT in CustTerms)
//                    {
//                        result = result + @"<option value=" + CT.TermsID + @">" + DRCM.fixstring(CT.TermsDescription) + @"</option>";
//                    }
//                    break;
//                case "STATELIST":
//                    List<DRC_StateProvenceList> States = DRCrepos.getStates();
//                    foreach (DRC_StateProvenceList ST in States)
//                    {
//                        result = result + @"<option value=" + ST.StateID + @">" + DRCM.fixstring(ST.StateName) + @"</option>";
//                    }
//                    break;
//                case "TAXCODE":
//                    List<DRC_TaxCode> Tax = DRCrepos.getTaxCodes();
//                    foreach (DRC_TaxCode T in Tax)
//                    {
//                        result = result + @"<option value=" + T.TaxCodeID + @">" + T.Name + @"|" + DRCM.fixstring(T.Description) + @"|" + T.CurrentRate.ToString() + @"</option>";
//                    }
//                    break;
//                case "STKBIN":
//                    List<DRC_ItemBin> Bin = DRCrepos.getItemBins();
//                    foreach (DRC_ItemBin B in Bin)
//                    {
//                        result = result + @"<option value=" + B.BinID + @">" + B.Name + @"</option>";
//                    }
//                    break;
//                case "STKBUILDING":
//                    List<DRC_ItemBuilding> Bldg = DRCrepos.getItemBuildings(Convert.ToInt32(filter));
//                    foreach (DRC_ItemBuilding B in Bldg)
//                    {
//                        result = result + @"<option value=" + B.BuildingID + @">" + B.Name + @"</option>";
//                    }
//                    break;
//                case "STKROOM":
//                    List<DRC_ItemRoom> Room = DRCrepos.getItemRooms();
//                    foreach (DRC_ItemRoom R in Room)
//                    {
//                        result = result + @"<option value=" + R.RoomID + @">" + R.Name + @"</option>";
//                    }
//                    break;

//            }

//            //complete select and add autolist functionality
//            result = result + @"</select></div>'); (function($) {
//		$.widget('ui." + name + @"', {
//			_create: function() {
//				var self = this;
//				var select = this.element.hide();
//				var input = $('<input>')
//					.insertAfter(select)
//					.autocomplete({
//						source: function(request, response) {
//							var matcher = new RegExp(request.term, 'i');
//							response(select.children('option').map(function() {
//								var text = $(this).text();
//                                    
//								if (this.value && (!request.term || matcher.test(text)))
//									return {
//										id: this.value,
//										label: text.replace(new RegExp('(?![^&;]+;)(?!<[^<>]*)(' + $.ui.autocomplete.escapeRegex(request.term) + ')(?![^<>]*>)(?![^&;]+;)', 'gi'), '<strong>$1</strong>'),
//										value: text
//									}
//							}));
//						},
//						delay: 0,
//						change: function(event, ui) {
//							if (!ui.item) {
//								// remove invalid value, as it didn't match anything
//								$(this).val('');
//                                
//								return false;
//							}
//							select.val(ui.item.id);
//
//							self._trigger('selected', event, {
//								item: select.find('[value=' + ui.item.id + ']')
//							});
//						
//						},
//						minLength: 0,
//                        select: function(event,ui){autoitem" + name + @"(ui.item);
//
//
//                        selitem" + name + @"=ui.item;
//
//                        sel" + name + @"=ui.item.id;   
//
//                        }
//                        
//                        
//					})
//					.addClass('ui-widget ui-widget-content ui-corner-left');
//
//$('<button>&nbsp;</button>')
//				.attr('tabIndex', -1)
//				.attr('title', 'Show All Items')
//				.insertAfter(input)
//				.button({
//					icons: { 
//						primary: 'ui-icon-triangle-1-s'
//					},
//					text: false
//				}).removeClass('ui-corner-all')
//				.addClass('ui-corner-right ui-button-icon')
//				.click(function() {
//					// close if already visible
//					if (input.autocomplete('widget').is(':visible')) {
//						input.autocomplete('close');
//						return;
//					}
//					// pass empty string as value to search for, displaying all results
//					input.autocomplete('search', '');
//					input.focus();
//
//				});
//			}
//		});
//
//	})(jQuery);
//
//		
//	$(function() {
//		$('#" + name + @"')." + name + @"();
//		$('#toggle').click(function() {
//			$('#" + name + @"').toggle();
//		});
//	});";
//            result = result + @" var selecteditem" + name + @"=''; function autoitem" + name + @"(data) {" + name + @"selecteditem=data;} ";

//            return result;
//        }
        public string savechanges()
        {

            string js = @" function SaveChanges_click() {

            $.post('/DRCCustomer/SaveChanges', {
                AcctID: $('#AcctID').attr('value'),
                Name: $('#Name').attr('value'),
                MainPhone: $('#MainPhone').attr('value'),
                Fax: $('#Fax').attr('value'),
                ADRStreet: $('#ADRStreet').attr('value'),
                ADRCity: $('#ADRCity').attr('value'),
                ADRState: $('#ADRState').attr('value'),
                ADRZip: $('#ADRZip').attr('value'),
                ADRCountry: $('#ADRCountry').attr('value'),
                Terms: $('#Terms').attr('value'),
                Website: $('#Website').attr('value')
            }, function (data) {alert(data); });

        }";
            return js;
        
        }
        public string getacctinfo()
        {
            string js= @"function getcustomer(data) {
                
                
            $.post('/DRCCustomer/custsel', { acctid: data }, function (data) {
                
                
                $('#Name').val(data.Name);
                $('#AcctID').val(data.AcctID);
                $('#MainPhone').val(data.MainPhone);
                $('#Fax').val(data.Fax);
                $('#ADRStreet').val(data.StreetAddress);
                $('#ADRCity').val(data.City);
                $('#ADRState').val(data.State);
                $('#ADRZip').val(data.ZipCode);
                $('#ADRCountry').val(data.Country);
                $('#OpeningBalDate').val(data.OpeningBalanceDate);
                $('#OpeningBal').val(data.OpeningBalance);
                $('#Terms').val(data.Terms);
                $('#Website').val(data.Website);
                


            });
        }
            
";
    return js;
        }

        public string CustomerSubMenu()
        {
            string js = @"$('#CustPaymentScreen').hide();
            $(CustRecPayment).hide();
        function CustRecPayment_click() {
            $('#CustPaymentScreen').toggle();
            $(divCustomerInfo).hide();
            
        }";
            return js;
        }
        public string MakeJobLogEquipTable(string div, string id,int AcctID,int JobID, int JobLogID)
        {
            string result = @" $(" + div + @").append('<table id="+id+@"><thead><tr><th>Name</th><th title=Equipment_Type>Type</th><th>Manufacture</th><th>Model</th><th title=Serial_Number>SN</th><th title=Customer_Location>CLoc</th><th title=Is_In_Shop>In</th><th title=Shop_Location>SLoc</th><th title=Return_Method>RM</th><th title=Estimated_Completion_Date>ECD</th><th title=Scheduled_Return_Date>SRD</th><th title=Actual_Return_Date>ARD</th></tr></thead><tbody id=" + id + @"body>";
            
            if (JobLogID > 0)//request from logID
            {

            }
            else
            {
                if (JobID > 0)//request from jobID
                {
                    var equip = from e in db.DRC_EquipmentRepairs where e.JobID == JobID select e;
                    if (equip.Count() > 0)
                    {
                        List<DRC_CustDevice> D = new List<DRC_CustDevice>();
                        foreach (var e in equip)
                        {
                            DRC_CustDevice device=(from d in db2.DRC_CustDevices where e.DeviceID == d.DeviceID select d).Single();
                            result = result + @"<tr><td>" + device.Name + @"</td><td>" + DRCrepos.getEquipmentTypefromTypeID( device.DeviceType) + @"</td><td>" +DRCrepos.getManNamefromManCode(device.Manufact) + @"</td><td>" +DRCrepos.getModelNamefromModelID(device.ModelID) + @"</td><td>" + device.SN + @"</td>";
                            result = result + @"<td>" + DRCrepos.getDeviceLocationNamefromID(device.LocationID) + @"</td><td>" + MakeInnerCheckbox("", id + "cbInshop", "Is_In_Shop","", Convert.ToBoolean(e.InShop)) + @"</td>";
                            result=result+@"<td>" +DRCrepos.getItemLocDescriptionfromLocID( e.InShopLocationID) + @"</td>";

result=result+@"<td>" + DRCrepos.getRetMethodNamefromID(Convert.ToInt32(e.ReturnMethodID)) + @"</td>";
if (e.EstimateCompleteDate != null)
    result = result + @"<td>" + e.EstimateCompleteDate.Value.ToShortDateString() + @"</td>";
else result = result + @"<td></td>";
if (e.ScheduledReturnDate != null)
    result = result + @"<td>" + e.ScheduledReturnDate.Value.ToShortDateString() + @"</td>";
else result = result + @"<td></td>";
if (e.ReturnDate != null)
    result = result + @"<td>" + e.ReturnDate.Value.ToShortDateString() + @"</td></tr>";
else result = result + @"<td></td></tr>";
                        }
                    }
                    
                }
                
            }


            result = result + @"</tbody></table>'); ";

            return result;
        }
        public string JobLogEquipmentTableAddRecord(DRCEquipmentRepair ER)
        {
            
            string result= @" $(tblEquipmentbody).append('<tr><td><button id=tblEquipment" + ER.DeviceID + @" onclick=showequiprepairdetails("+ER.EquipRepID+@")>" + ER.DeviceName + @"</button></td><td>" + DRCrepos.getEquipmentTypefromTypeID(Convert.ToInt32(ER.DeviceTypeID)) + @"</td><td>" + DRCrepos.getManNamefromManCode(Convert.ToInt32(ER.DevMan)) + @"</td><td>" + DRCrepos.getModelNamefromModelID(Convert.ToInt32(ER.DevModel)) + @"</td><td>" + ER.DevSN + @"</td></tr>'); ";

            result = result + @" function showequiprepairdetails(er){$.post('/DRCCustomer/DisplayERDetails',{ER:er}); }";
            return result;
        }
        public string ShowEquipmentRepairDetails(DRC_EquipmentRepair ER)
        {
            string result="";
            
            return result;
        }
        public string MakeEquipRepairDetailsTables(DRCEquipmentRepair ER)
        {
            string result = "";
            result = result + @" $(divequiprepairdetails).empty(); ";
            result = result + @" $(divequiprepairdetails).append('<table><tr><th>HELLO</th></tr><tr><td>"+ER.EquipRepID+@"</td></tr></table>'); ";
            return result;
        }

        public string DatePicker()
        {
            string js = @"$(function () {
            $('#datepicker').datepicker({
                changeMonth: true,
                changeYear: true
            });
        });";
            return js;
        }
        public string moneyfield()
        {
            string js = @"var keypress = 0;
            var Pamt = String('$0');
            $('#payamt').keyup(function (event) {
                var strout = String('');
                var code = event.keyCode;
                switch (code) {
                    case 8:
                        keypress--;
                        if (keypress < 1) {
                            strout = '$0';
                            keypress = 0;
                        }
                        else {
                            switch (keypress) {
                                case 1:
                                    Pamt = '$0.0' + Pamt.substr(3, 1);
                                    break;
                                case 2:
                                    Pamt = '$0.' + Pamt.substr(1, 1) + Pamt.substr(3, 1);
                                    break;
                                default:
                                    Pamt = Pamt.substr(0, Pamt.length - 4) + '.' + Pamt.substr(Pamt.length - 4, 1) + Pamt.substr(Pamt.length - 2, 1);
                                    break;

                            }
                            strout = Pamt;
                        }

                        break;
                    
                    case 46:
                        strout = '$0';
                        keypress = 0;
                        break;

                    case 16:    //shift key

                        break;
                    case 17:    //CTRL key
                        break;
                    case 18:    //ALT key
                        break;

                    default:

                        if (!((code > 47 & code < 58) | (code > 95 & code < 106))) {
                            
                            strout = Pamt;
                        }
                        else {
                            keypress++;
                            if (code > 95) {
                            code = code - 48;
                            }
                            switch (keypress) {
                                case 1:
                                    if (code != 48) {
                                        strout = '$0.0' + String.fromCharCode(code);
                                    }
                                    else {
                                        keypress = 0;
                                        strout = '$0';
                                    }
                                    break;
                                case 2:
                                    strout = '$0.' + Pamt.substr(4, 1) + String.fromCharCode(code);
                                    break;
                                case 3:
                                    strout = '$' + Pamt.substr(3, 1) + '.' + Pamt.substr(4, 1) + String.fromCharCode(code);

                                    break;
                                default:

                                    strout = Pamt.substr(0, Pamt.length - 3) + Pamt.substr(Pamt.length - 2, 1) + '.' + Pamt.substr(Pamt.length - 1, 1) + String.fromCharCode(code);
                                    break;

                            }

                        Pamt = strout;
                    }

                        break;

                }
            $('#payamt').val(strout);
        });";
            return js;
        }
        public string moneyvalidatedfield(string name)
        {
            
            string result = @"var keyp = 0;
            var Pamt = String('$0');
            $("+name+ @").keyup(function (event) {
                var strout = String('');
                var code = event.keyCode;
                switch (code) {
                    case 8:
                        keyp--;
                        if (keyp < 1) {
                            strout = '$0';
                            keyp = 0;
                        }
                        else {
                            switch (keyp) {
                                case 1:
                                    Pamt = '$0.0' + Pamt.substr(3, 1);
                                    break;
                                case 2:
                                    Pamt = '$0.' + Pamt.substr(1, 1) + Pamt.substr(3, 1);
                                    break;
                                default:
                                    Pamt = Pamt.substr(0, Pamt.length - 4) + '.' + Pamt.substr(Pamt.length - 4, 1) + Pamt.substr(Pamt.length - 2, 1);
                                    break;

                            }
                            strout = Pamt;
                        }

                        break;
                    
                    case 46:
                        strout = '$0';
                        keyp = 0;
                        break;

                    case 16:    //shift key

                        break;
                    case 17:    //CTRL key
                        break;
                    case 18:    //ALT key
                        break;

                    default:

                        if (!((code > 47 & code < 58) | (code > 95 & code < 106))) {
                            
                            strout = Pamt;
                        }
                        else {
                            keyp++;
                            if (code > 95) {
                            code = code - 48;
                            }
                            switch (keyp) {
                                case 1:
                                    if (code != 48) {
                                        strout = '$0.0' + String.fromCharCode(code);
                                    }
                                    else {
                                        keyp = 0;
                                        strout = '$0';
                                    }
                                    break;
                                case 2:
                                    strout = '$0.' + Pamt.substr(4, 1) + String.fromCharCode(code);
                                    break;
                                case 3:
                                    strout = '$' + Pamt.substr(3, 1) + '.' + Pamt.substr(4, 1) + String.fromCharCode(code);

                                    break;
                                default:

                                    strout = Pamt.substr(0, Pamt.length - 3) + Pamt.substr(Pamt.length - 2, 1) + '.' + Pamt.substr(Pamt.length - 1, 1) + String.fromCharCode(code);
                                    break;

                            }

                        Pamt = strout;
                    }

                        break;

                }
            $(" + name+@").val(strout);
        });";
            return result;
        }
        public string custpayment()
        {
            string js = @"var Pacct;
        var PDocFriendName;
        var PDocType;
        var PDocLineType;
        var PCustID;
        var PMethod;
        var Pamt;

  function resetPdetails(){
            $(datepicker).val('');
            $(payref).val('Reference');
            $(payamt).val('$0');
            $(CustPaymentScreen).hide();
            $('#PaymentDetails').hide();
            $('#PostPayment').hide();
            $('#PurchasePayment').show();
            $('#OtherPayment').show();
            $('#CustRecPayment').show();
            keyp=0;
            
}       

    resetPdetails();
        
    function PaymentSetup(){
            $('#PurchasePayment').hide();
            $('#OtherPayment').hide();
            $('#PaymentDetails').show();
            $('#PostPayment').show();
}        

 function PurchasePayment_click() {
            PaymentSetup();
            $(OtherPdetails).hide();
            PDocType = 11;
            PDocFriendName = 'Customer Payment';
            PDocLineType = 0;
            Pacct = 0;
            CreatePaymentMethods();
        }

        function OtherPayment_click() {
            PaymentSetup();
            $('#lblPayAcct').show();
            $(OtherPdetails).show();
            PDocType = 45;
            PDocFriendName = 'Other Payment';
            PDocLineType = 51;
            Pacct = 0;
            $.post('DRCCustomer/expenselist',function(data){});
            CreatePaymentMethods();
           
        }
            function PostPayment_click() {
            
                $.post('/DRCCustomer/PostCustomerPayment',{PDate:$('#datepicker').val(),PRef:$(payref).val(),PAmt:Pamt,ExAcct:Pacct,PCustID:PCustID,PDocType:PDocType,PDocLineType:PDocLineType,PDocFriendName:PDocFriendName,PMethod:PMethod},function(data){alert(data);
                resetPdetails();
                $(divCustomerInfo).show();
         

});
        } function PaymentMethod_click(data) {PMethod = data; } function expenseitem(data) {
            $('#exacct').attr('value', data.value);
            Pacct = data.id;
            $('#exacct').show();
}
 
        function CreatePaymentMethods() {
            $(PayType).empty();
            $('#PayType').append('<input type=radio name=PaymentMethod value=1 onclick=PaymentMethod_click(value)><label for=Check>Check</label><input type=radio name=PaymentMethod value=4 onclick=PaymentMethod_click(value)><label for=Cash>Cash</label><input type=radio name=PaymentMethod value=0 onclick=PaymentMethod_click(value)><label for=Credit>Credit</label><input type=radio name=PaymentMethod value=2 onclick=PaymentMethod_click(value)><label for=ElectronicTransfer>Electronic Transfer</label><input type=radio name=PaymentMethod value=8 onclick=PaymentMethod_click(value)><label for=CompanyCredit>Company Credit</label><div>');
            
}

       
        function CancelPayment_click(){
            resetPdetails();
            $(divCustomerInfo).show();
            alert('Payment from '+PCustID+'-'+selCustName+' Cancled');
        
            
        
        
}";
            return js;
        }
        public string CompanyStart()
        {
            string js = @"$('#CustPaymentScreen').hide();
            
";

            return js;
        }
        public string PaymentMethod()
        {
            string js = @"var PMethod;
    $(PayType).empty();
    $('#PayType').append('<input type=radio name=PaymentMethod value=1 onclick=PaymentMethod_click(value)><label for=Check>Check</label><input type=radio name=PaymentMethod value=4 onclick=PaymentMethod_click(value)><label for=Cash>Cash</label><input type=radio name=PaymentMethod value=0 onclick=PaymentMethod_click(value)><label for=Credit>Credit</label><input type=radio name=PaymentMethod value=2 onclick=PaymentMethod_click(value)><label for=ElectronicTransfer>Electronic Transfer</label><input type=radio name=PaymentMethod value=8 onclick=PaymentMethod_click(value)><label for=CompanyCredit>Company Credit</label><div>');
    function PaymentMethod_click(data) { PMethod = data; }";
            return js;
        }
        public string TermsBox()
        {
            return @"function termsitem(data) {
$('#Terms').attr('value', data.value);
Pacct = data.id;
$('#Terms').show();
}
";
        }
        public string MakeDDLOptions(string id, string type, string filter)
        {
            string result = @"$("+id+@").empty(); $(" + id + @").append('";

            switch (type)
            {
                case "MANoverMODEL":
                    List<DRC_ItemModel> IM = DRCrepos.getManModels(Convert.ToInt32(filter));
                    if (IM.Count > 0)
                    {
                        foreach (DRC_ItemModel item in IM)
                        {
                            result = result + @"<option value=" + item.ModelID + @">" + item.Name + @"</option>";
                        }
                    }
                    else result = result + @"<option value=0 selected=selected>NEW MODEL</option>";

                    break;
                
                default:
                    break;
            }
            result = result + @"'); ";
            return result;
        }
        public string FillDataTable(Array Hrow,Array tdTypes,string tblid)
        {
            string headerrow = "";
            string[] rlbl = new string[Hrow.Length];
            int count = 0;
            foreach (string r in Hrow)
            {
                headerrow = headerrow + @"<th>" +r+  @"</th>";
                rlbl[count] = r;
                count++;
            }
            headerrow = @"'<tr>" + headerrow + @"</tr>";
            string datarow = "<tr>";
            count = 0;
            foreach (string t in tdTypes)
            {
                 switch (t)
                {
                    case "textbox":
                        datarow = datarow + @"<td><input id='row" + count+rlbl[count] + @"' type='text' class=cls" + tblid + @" /></td>";
                        break;
                    case "checkbox":
                        break;
                    case "ddl":
                        break;
                    case "label":
                        datarow = datarow + @"<td><label id='row" + count + rlbl[count] + @"'>test label</label></td>";
                        break;
                    case "button":
                        break;
                    case "date"://need to string the date for proper page display
                         
                        break;
                    
                }
                count++;
            }
            string js = headerrow+datarow+@"</tr>'";
            
            return js;
        }
        public string AddInputBox(int h, int w, string div, string id, int top, int left, string title, string lbl,int fntsz, string defval)
        {
            
            string result = @" $(" + div + @").append('<label id=lbl" + id + @" style=position:fixed;display:block;font-size:"+fntsz+@"px;width:" + w + @"px;height:" + h + @"px;top:" + (top - h-7) + @"px;left:" + left + @"px>" + lbl + @"</label>');";
            result = result + @"$(" + div + @").append('<input id=" + id + @" title=" + title + @" style=position:fixed;font-size:" + fntsz + @"px;display:block;width:" + w + @"px;height:" + h + @"px;top:" + top + @"px;left:" + left + @"px>'); $(" + id + @").val('" + defval + @"'); ";
            return result;
        }
        public string AddInputBox(string div, string id, string title, string lbltext, string defval)
        {
            string result = @" $(" + div + @").append('<label id=lbl" + id + @">"+lbltext+@"</label>');";
            result=result+ @"$(" + div + @").append('<input id=" + id + @" title=" + title + @">"+defval+@"</input>'); ";
            return result;
        }
        public string MakeInputBox(string lblclass, string tbclass,string div, string name, string title, string lbltext, string defval)
        {
            string result = @" $(" + div + @").append('<label id=lbl" + name + @" class="+lblclass+@">" + lbltext + @"</label>');";
            result = result + @"$(" + div + @").append('<input id=" + name + @" title=" + title + @" class="+tbclass+@"></input>'); $(" + name + @").val('" + defval + @"'); ";
            return result;
        }
        public string MakeGroupedInputBox(string div, string id, string title, string lbltext, string defval,string postype)
        {

            string result = @" $(" + div + @").append('<label id=lbl" + id + @" style=position:" + postype + @";display:block>" + lbltext + @"</label>');";
            result = result + @"$(" + div + @").append('<input id=" + id + @" title=" + title + @" style=position:" + postype + @";display:block></input>'); $("+id+@").val('"+defval+@"'); ";
            return result;
        }
        public string MakeGroupedTextArea(string div, string name, string title, string lbltext, string defval, string postype)
        {
            string result = "";
            string lbl = @" $(" + div + @").append('<label id=lbl" + name + @" style=position:"+postype+@";display:block>" + lbltext + @"</label>');";
            string TA = @" $(" + div + @").append('<textarea id=" + name + @" title=" + title + @" style=position:" + postype + @";display:block>" + defval + @"</textarea>');";
            result = lbl + TA;
            return result;
        }
        public string MakeTextArea(string lblclass, string taclass, string div, string name, string title, string lbltext, string defval,int rows,int cols)
        {
            string result = "";
            string lbl = @" $(" + div + @").append('<label id=lbl" + name + @" class="+lblclass+@">" + lbltext + @"</label>');";
            string TA = @" $(" + div + @").append('<textarea rows=" + rows + @" cols=" + cols + @" id="+name+@" title="+title+@" class="+taclass+@">"+defval+@"</textarea>');";
            result = lbl + TA;
            return result;
        }
        public string MakePhoneInput(string tbclass,string lblclass, string div, string id, string title, string lbl,string defval)
        {
            string result = @" $(" + div + @").append('<label id=lbl" + id + @" class="+lblclass+@">" + lbl + @"</label>');";
            result = result + @"$(" + div + @").append('<input id=" + id + @" title=" + title + @" class="+tbclass+@">');

           $(" + id + @").val('" + defval + @"');
           var " + id + @"data='" + defval + @"';     //to handle stuck or held down key
            //using keyup event to handle invalid keys since characters are added to input field after keypress fuction occurs.
                
                $(" + id + @").keyup(function(){
                
                      $(" + id + @").val(" + id + @"data);
                      " + id + @"kup=true;
            });
            
          
           $(" + id + @").keydown(function (event) {
              
                var " + id + @"code = event.keyCode;
                
            
            switch (" + id + @"code)
                {
                   
                        case 8:
                        
                        
                             " + id + @"data=(" + id + @"data.substr(0," + id + @"data.length-1));
                             
                            
                        
                        break;

                    default:
                                //Convert numeric pad input to proper code for output
                                if (" + id + @"code > 95) {
                            " + id + @"code = " + id + @"code - 48;
                            }

                        if (" + id + @"code > 47 && " + id + @"code < 58)
                            
                            {
                                if(" + id + @"kup==true)
                                {
                                switch($(" + id + @").val().length)
                                {
                                    case 0:
                                       " + id + @"data='('+String.fromCharCode(" + id + @"code);
                                    break;
                                    case 4:
                                       " + id + @"data=" + id + @"data+') '+ String.fromCharCode(" + id + @"code);
                                    break;
                                    case 9:
                                       " + id + @"data=" + id + @"data+'-'+ String.fromCharCode(" + id + @"code);
                                    break;
                                    case 14:
                                       " + id + @"data=" + id + @"data+' x'+ String.fromCharCode(" + id + @"code);
                                    break;
                                    default:
                                    " + id + @"data=" + id + @"data+String.fromCharCode(" + id + @"code);
                                    break;
                                    
                                }
                                    
                            }
                                   " + id + @"kup=false;
                            }
                        break;

                }

           
        });
                               


";
            return result;
        }
        public string MakeGroupedPhoneInput(string div, string id, string title, string lbl, string defval,string postype)
        {
            string result = @" $(" + div + @").append('<label id=lbl" + id + @" style=position:"+postype+@";display:block>" + lbl + @"</label>');";
            result = result + @"$(" + div + @").append('<input id=" + id + @" title=" + title + @" style=position:" + postype + @">');

           $(" + id + @").val('"+defval+@"');
           var " + id + @"data='" + defval + @"';
           var " + id + @"kup=true;     //to handle stuck or held down key
            //using keyup event to handle invalid keys since characters are added to input field after keypress fuction occurs.
                
                $(" + id + @").keyup(function(){
                
                      $(" + id + @").val(" + id + @"data);
                      " + id + @"kup=true;
            });
            
          
           $(" + id + @").keydown(function (event) {
              
                var " + id + @"code = event.keyCode;
                
            
            switch (" + id + @"code)
                {
                    case 8:
                        
                        
                             " + id + @"data=(" + id + @"data.substr(0," + id + @"data.length-1));
                             
                            
                        
                        break;

                    default:
                                //Convert numeric pad input to proper code for output
                                if (" + id + @"code > 95) {
                            " + id + @"code = " + id + @"code - 48;
                            }

                        if (" + id + @"code > 47 && " + id + @"code < 58)
                            
                            {
                                if(" + id + @"kup==true)
                                {
                                switch($(" + id + @").val().length)
                                {
                                    case 0:
                                       " + id + @"data='('+String.fromCharCode(" + id + @"code);
                                    break;
                                    case 4:
                                       " + id + @"data=" + id + @"data+') '+ String.fromCharCode(" + id + @"code);
                                    break;
                                    case 9:
                                       " + id + @"data=" + id + @"data+'-'+ String.fromCharCode(" + id + @"code);
                                    break;
                                    case 14:
                                       " + id + @"data=" + id + @"data+' x'+ String.fromCharCode(" + id + @"code);
                                    break;
                                    default:
                                    " + id + @"data=" + id + @"data+String.fromCharCode(" + id + @"code);
                                    break;
                                    
                                }
                                    
                            }
                                   " + id + @"kup=false;
                            }
                        break;

                }

           
        });
                               


";
            return result;
        }
        public string MakeZipCodeInput(int h, int w, string div, string id, int top, int left, string title, string lbl, int fntsz)
        {
            string result = @" $(" + div + @").append('<label id=lbl" + id + @" style=position:fixed;display:block;font-size:" + fntsz + @"px;width:" + w + @"px;height:" + h + @"px;top:" + (top - h - 7) + @"px;left:" + left + @"px>" + lbl + @"</label>');";
            result = result + @"$(" + div + @").append('<input id=" + id + @" title=" + title + @" style=position:fixed;font-size:" + fntsz + @"px;display:block;width:" + w + @"px;height:" + h + @"px;top:" + top + @"px;left:" + left + @"px>');

            var " + id + @"keypress = 0;
            var " + id + @"Pamt = String('');
            $(" + id + @").keyup(function (event) {
                var " + id + @"strout = String('');
                var " + id + @"code = event.keyCode;
                
                switch (" + id + @"code) {
                    case 8:
                        " + id + @"keypress--;
                        if (" + id + @"keypress < 0) {
                            " + id + @"strout = '';
                            " + id + @"keypress = 0;
                        }
                        else {
                                    if (" + id + @"keypress==5) {" + id + @"Pamt = " + id + @"Pamt.substr(0, " + id+@"Pamt.length - 2);
                                            }       
                                    
                                    else{
                                            " + id + @"Pamt = " + id + @"Pamt.substr(0, " + id + @"Pamt.length - 1);
                                            }

                        " + id + @"strout = " + id + @"Pamt;
                        }
                               
                        break;

                    case 16:    //shift key

                        break;
                    case 17:    //CTRL key
                        break;
                    case 18:    //ALT key
                        break;

                    default:

                        if (!((" + id + @"code > 47 & " + id + @"code < 58) | (" + id + @"code > 95 & " + id + @"code < 106))) {
                            
                            " + id + @"strout = " + id + @"Pamt;
                        }
                        else {
                            " + id + @"keypress++;
                            if (" + id + @"code > 95) {
                            " + id + @"code = " + id + @"code - 48;
                            }

                            switch (" + id + @"keypress) {
                                
                                case 6:
                                    " + id + @"strout = " + id + @"Pamt +'-'+ String.fromCharCode(" + id + @"code);
                                    break;

                                default:

                                    " + id + @"strout = " + id + @"Pamt + String.fromCharCode(" + id + @"code);
                                    break;

                            }

                        " + id + @"Pamt = " + id + @"strout;
                    }

                        break;

                }
                    
            $(" + id + @").val(" + id + @"strout);
        });
                               


";
            return result;
        }
        public string MakeCheckbox(int h, int w, string div, string id, int top, int left, string title, string val, string lbl)
        {
            string result = @" $(" + div + @").append('<label id=lbl" + id + @" style=position:fixed;display:block;width:" + w + @"px;height:" + h + @"px;top:" + (top - h) + @"px;left:" + left + @"px>"+lbl+@"</label>');";
            result=result+ @" $(" + div + @").append('<input id=" + id + @" title=" + title + @" type=checkbox value="+val+@"  style=position:fixed;display:block;top:" + top + @"px;left:" + left + @"px>');";
            return result;
        }
        public string MakeCheckbox(string cblblclass,string cbclass,string div, string id, string lbl, string title, string clkfunc,bool check)
        {
            string action = @"var " + id + @"var=false; ";
            string result = "";
            if (!(div == ""))
            {
                result = @" $(" + div + @").append('<label id=lbl" + id + @" class=" + cblblclass + @">" + lbl + @"</label>');";
                result = result + @" $(" + div + @").append('<input id=" + id + @" title=" + title + @" type=checkbox class=" + cbclass + @" ";
                if (check)
                {
                    result = result + @" checked=checked ";
                    action = @" " + id + @"var=true; ";
                }
                //if (clkfunc != "")
                //{ result = result + @"onclick=" + clkfunc + @">');"; }
                //else { result = result + @">');"; }
                result = result + @">');";
            }
            else
            {
                result=@"<input id=" + id + @" title=" + title + @" type=checkbox class=" + cbclass + @" ";
                if (check)
                {
                    result = result + @" checked=checked ";
                    action = @" " + id + @"var=true; ";
                }
                result = result + @">";
            }
            action = action + @" $(" + id + @").click(function(){" + id + @"var=document.getElementById('" + id + @"').checked; "+clkfunc+@"}); ";
            result = result + action;
            return result;
        }
        public string MakeInnerCheckbox(string cbclass, string id, string title, string clkfunc, bool check)
        {
            string result = @"<input id=" + id + @" title=" + title + @" type=checkbox class=" + cbclass + @" ";
            if (check)
            {
                result = result + @" checked=checked ";
            }
            result = result + @" onclick="+clkfunc+@">";
            return result;
        }
        public string MakeCheckboxList(string cblblclass, string cbclass,string cbListTitleClass ,string div, string id, string TitleText, List<CBList> boxes)
        {

            string result = @" $(" + div + @").append('<label id=lbl" + id + @" class=" + cbListTitleClass + @">" + TitleText + @"</label>');";
            foreach (CBList cb in boxes)
            {
                result = result+@" $(" + div + @").append('<label id=lbl" + id +cb.name+ @" class=" + cblblclass + @">" + cb.name + @"</label>');";
                result = result + @" $(" + div + @").append('<input id=" + id + @" title=" + cb.name + @" type=checkbox class=" + cbclass + @" ";
                if (cb.check)
                {
                    result = result + @" checked=checked ";
                }
                result = result + @">');";
            }
            return result;
        }
        public string MakeLabel(string lblclass,string div, string name, string lbltext)
        {
            return @" $(" + div + @").append('<label id=" + name + @" class="+lblclass+@">" + lbltext + @"</label>'); ";
        }
        public string MakeGroupedLabel(string div, string name, string title, string txt, string postype)
        {
            return @" $(" + div + @").append('<label id=" + name + @" style=position:" + postype +  @">" + txt + @"</label>'); ";
        }
        public string MakeAnchor(string lblclass, string div, string name, string lbltext)
        {
            if (lbltext == null) { lbltext = @"http://www.google.com"; }
            
            if (lbltext.Length>8 && (lbltext.Substring(0, 7) == @"http://" || lbltext.Substring(0, 8) == @"https://" || lbltext.Substring(0, 7) == @"HTTP://" || lbltext.Substring(0, 8) == @"HTTPS://"))
            {
                return @" $(" + div + @").append('<a target=_blank href="+lbltext+@" id=" + name + @" class=" + lblclass + @">" + lbltext + @"</a>'); ";
            }
            else
            {
                return @" $(" + div + @").append('<label id=" + name + @" class=" + lblclass + @">" + lbltext + @"</label>'); ";
            }
        }
        public string MakeGroupedAnchor(string div, string name, string title, string txt, string postype)
        {
            if (txt == null) { txt = @"http://www.google.com"; }
            string pattern = "^http[:,s:]////";
            Regex rgx = new Regex(pattern);
            if (rgx.Match(txt).Success)
            {
                return @"<a href='" + txt + @"' id=" + name + @" style=position:" + postype + @">" + txt + @"</a>'); ";
            }

            else return @" $(" + div + @").append('<label id=" + name + @" style=position:" + postype + @">" + txt + @"</label>'); ";
            

        }
        public string validators()
        {
            return @" var dateRE=/^((((0[13578])|([13578])|(1[02]))[\/](([1-9])|([0-2][0-9])|(3[01])))|(((0[469])|([469])|(11))[\/](([1-9])|([0-2][0-9])|(30)))|((2|02)[\/](([1-9])|([0-2][0-9]))))[\/]\d{4}$|^\d{4}$/; testregx=/1/g; var moneyRE=/^\$\d{1,}.\d{2}$/; var fieldRE=/.{1,}/; var ZipRE=/^\d{5}\-?\d{4}?/; var emailRE=/\@/; var WebRE=/^\http\.?/; var tdate=false; var taccteql=true; var tamt=false; var tfield=false; var inttest=/^$\d/; var tsel=false; var phoneRE=/^\(\d{3}\)\s\d{3}\-\d{4}\.?/; var tphone=false; var tWeb=false; var tZip=true; var tEmail;

          function valdate(D){if(dateRE.test(D)) {tdate=true;} else{tdate=false}}

          function valcreddebaccts(sa,ta){if(sa==ta){taccteql=true;} else{taccteql=false;}}
          
          function valmoney(M){if(moneyRE.test(M)) {tamt=true;} else{tamt=false;}}  
          
          function valfield(F){if(fieldRE.test(F)) {tfield=true;} else{tfield=false;}}
          
          function valselection(S,D,L){if(S>0) {$(D).css({'border': '0px none '}); $(L).css('color','green'); tsel=true;} else{$(D).css({'border': 'thick double crimson'}); $(L).css('color','crimson'); tsel=false; alert('Selection Required '+S);}}
          
          function valField2(F,M){if(fieldRE.test($(F).val())) {$(F).css('background-color','olive'); tfield=true;} else{$(F).css('background-color','crimson'); tfield=false; alert(M+' is a required field');}}
          
          function valUSphone(F,M){if(phoneRE.test($(F).val())) {$(F).css('background-color','olive'); tphone=true;} else{$(F).css('background-color','crimson'); tphone=false; alert(M+' must be of the form (nnn) nnn-nnnn[ x...]');}}
          
          function valWebSite(F,M){if(WebRE.test($(F).val())) {$(F).css('background-color','olive'); tWeb=true;} else{$(F).css('background-color','crimson'); tWeb=false; alert(M+' must start with http:// or https://');}}

          function valZipCode(F,M){if(ZipRE.test($(F).val())) {$(F).css('background-color','olive'); tZip=true;} else{$(F).css('background-color','crimson'); tZip=false; alert(M+' must be of the form nnnnn[-nnnn]');}}

function valEmail(F,M){if(emailRE.test($(F).val())) {$(F).css('background-color','olive'); tEmail=true;} else{$(F).css('background-color','crimson'); tEmail=false; alert(M+' must have an @ sign.');}}
          
          
";
        }
        public string MoneyMeter(string DIV)
        {
            return @" $(" + DIV + @").prepend('<img id=moneymeterbackground src=../../Content/Images/MoneyMeterbar.png alt=Money Meter /><img id=hundreths src=../../Content/Images/MoneyMeter0.png alt=HundrethsPlace /><img id=tenths src=../../Content/Images/MoneyMeter0.png alt=Tenths Place /><img id=ones src=../../Content/Images/MoneyMeter0.png alt=Ones Place /><img id=tens src=../../Content/Images/MoneyMeter0.png alt=Tens Place /><img id=hundreds src=../../Content/Images/MoneyMeter0.png alt=Hundreds Place /><img id=thousands src=../../Content/Images/MoneyMeter0.png alt=Thousands Place /><img id=tenthousands src=../../Content/Images/MoneyMeter0.png alt=Ten Thousands Place /><img id=hundredthousands src=../../Content/Images/MoneyMeter0.png alt=Hundred Thousands Place /><img id=millions src=../../Content/Images/MoneyMeter0.png alt=Millions Place /><img id=tenmillions src=../../Content/Images/MoneyMeter0.png alt=Ten Millions Place /><img id=hundredmillions src=../../Content/Images/MoneyMeter0.png alt=Hundred Millions Place />');";
        }
        public string MakePostButton(string btnID, string DIV, string clickfunction,int top, int left)
        {
            return @"$(" + DIV + @").append('<input type=button id=" + btnID + @" onclick=" + clickfunction + @" value=POST  style=position:fixed;display:block;left:" + left + @"px;top:" + top + @"px onmouseover=smsov(" + btnID + @") onmouseout=smsout(" + btnID + @")>'); function smsov(nm){$(nm).css({'background-color':'yellow'});}
            function smsout(nm){$(nm).css({'background-color':'#D9D9D9'});}
            ";
        }
        public string MakeButton(string btnID, string DIV, string clickfunction, int top, int left,string txt)
        {
            return @" var data"+btnID+@"='"+btnID+@"'; $(" + DIV + @").append('<button id=" + btnID + @" onclick=" + clickfunction + @"(data"+btnID+@") style=position:fixed;display:block;left:" + left + @"px;top:" + top + @"px>"+txt+@"</button>');
            ";
        }
        public string MakeButton(string btnID, string DIV, string clickfunction, string txt)
        {
            return @" var data" + btnID + @"='" + btnID + @"'; $(" + DIV + @").append('<button id=" + btnID + @" onclick=" + clickfunction + @"(data" + btnID + @") style=width:" + txt.Length + @">" + txt + @"</button>');
            ";
        }
        public string MakeButton2(string btnID, string DIV, string btnclass, string txt, string clickfunction)
        {
            string result = "";
            
                result= @" var data" + btnID + @"='" + btnID + @"'; $(" + DIV + @").append('<button id=" + btnID + @" style=width:" + txt.Length + @" class=" + btnclass + @">" + txt + @"</button>');
                        $(" + btnID + @").click(function() {" + clickfunction + @"});
                    ";
            
            
            return result;
        }
        public string MakeCancelButton(string btnID, string DIV, string clickfunction, int top, int left)
        {
            return @"$(" + DIV + @").append('<input type=button id=" + btnID + @" onclick=" + clickfunction + @" value=CANCEL  style=position:fixed;display:block;left:" + left + @"px;top:" + top + @"px onmouseover=cmsov(" + btnID + @") onmouseout=cmsout(" + btnID + @")>'); function cmsov(nm){$(nm).css({'background-color':'red'});}
            function cmsout(nm){$(nm).css({'background-color':'#D9D9D9'});}";
        }
        public string MakeDateField(int h, int w, string div, string id, int top, int left)
        {
            string js = @"$(" + div + @").append('<input class=FinDate id=" + id + @" style=position:fixed;display:block;width:" + w + @"px;height:" + h + @"px;top:" + top + @"px;left:" + left + @"px>'); ";
            js = js+@" $(function () {
            $('#"+id+@"').datepicker({
                changeMonth: true,
                changeYear: true
            });
        }); ";
            return js;
        }
        public string MakeDateField(string dateclass, string div, string id, string datein)
        {
            string js = @"$(" + div + @").append('<input class="+dateclass+@" id=" + id + @">'); ";
            js = js + @" $(function () {
            $('#" + id + @"').datepicker({
                changeMonth: true,
                changeYear: true
            });
        }); $("+id+@").val('"+datein+@"'); ";
            return js;
        }
        public string MakeMoneyField(string div, string id, int h, int w, int top, int left)
        {
            string result = "";
            result=@"$(" + div + @").append('<input id=" + id + @" style=position:fixed;display:block;height:"+h+@"px;width:"+w+@"px;top:" + top + @"px;left:" + left + @"px value=$0>'); var "+id+@"keypress = 0;
            var "+id+@"Pamt = String('$0');
            $("+id+@").keyup(function (event) {
                var "+id+@"strout = String('');
                var "+id+@"code = event.keyCode;
                
                switch (" +id+@"code) {
                    case 8:
                        "+id+@"keypress--;
                        if ("+id+@"keypress < 1) {
                            "+id+@"strout = '$0';
                            "+id+@"keypress = 0;
                        }
                        else {
                            switch ("+id+@"keypress) {
                                case 1:
                                    "+id+@"Pamt = '$0.0' + "+id+@"Pamt.substr(3, 1);
                                    break;
                                case 2:
                                    "+id+@"Pamt = '$0.' + "+id+@"Pamt.substr(1, 1) + "+id+@"Pamt.substr(3, 1);
                                    break;
                                default:
                                    "+id+@"Pamt = "+id+@"Pamt.substr(0, "+id+@"Pamt.length - 4) + '.' + "+id+@"Pamt.substr("+id+@"Pamt.length - 4, 1) + "+id+@"Pamt.substr("+id+@"Pamt.length - 2, 1);
                                    break;

                            }
                            "+id+@"strout = "+id+@"Pamt;
                        }

                        break;
                    
                    case 46:
                        "+id+@"strout = '$0';
                        "+id+@"keypress = 0;
                        break;

                    case 16:    //shift key

                        break;
                    case 17:    //CTRL key
                        break;
                    case 18:    //ALT key
                        break;

                    default:

                        if (!(("+id+@"code > 47 & "+id+@"code < 58) | ("+id+@"code > 95 & "+id+@"code < 106))) {
                            
                            "+id+@"strout = "+id+@"Pamt;
                        }
                        else {
                            "+id+@"keypress++;
                            if ("+id+@"code > 95) {
                            "+id+@"code = "+id+@"code - 48;
                            }
                            switch ("+id+@"keypress) {
                                case 1:
                                    if ("+id+@"code != 48) {
                                        "+id+@"strout = '$0.0' + String.fromCharCode("+id+@"code);
                                    }
                                    else {
                                        "+id+@"keypress = 0;
                                        "+id+@"strout = '$0';
                                    }
                                    break;
                                case 2:
                                    "+id+@"strout = '$0.' + "+id+@"Pamt.substr(4, 1) + String.fromCharCode("+id+@"code);
                                    break;
                                case 3:
                                    "+id+@"strout = '$' + "+id+@"Pamt.substr(3, 1) + '.' + "+id+@"Pamt.substr(4, 1) + String.fromCharCode("+id+@"code);

                                    break;
                                default:

                                    "+id+@"strout = "+id+@"Pamt.substr(0, "+id+@"Pamt.length - 3) + "+id+@"Pamt.substr("+id+@"Pamt.length - 2, 1) + '.' + "+id+@"Pamt.substr("+id+@"Pamt.length - 1, 1) + String.fromCharCode("+id+@"code);
                                    break;

                            }

                        "+id+@"Pamt = "+id+@"strout;
                    }

                        break;

                }
            $("+id+@").val("+id+@"strout);
        });";


            return result;
        }
        public string MakeInputActionField(string div, string id, string lblclass, string tbclass,string lbltext,string title, string defval, string focusaction, string bluraction)
        {
            string result = @" $(" + div + @").append('<label id=lbl" + id + @">" + lbltext + @"</label>');";
            result = result + @"$(" + div + @").append('<input id=tb" + id + @" title=" + title + @" onblur=blurf() onfocus=focus()>" + defval + @"</input>'); ";
            string action = @" function blurf(){" + bluraction + @"} function focusf(){" + focusaction + @"} ";
            return result+action;
        }
        public string MakeMoneyField(string div, string id, int h, int w, int top, int left,string mlabel)
        {
            string result = "";
            result = @"$(" + div + @").append('<input id=" + id + @" style=position:fixed;display:block;height:" + h + @"px;width:" + w + @"px;top:" + top + @"px;left:" + left + @"px value=$0><label for=" + id + @" style=position:fixed;display:block;top:" + (top-h) + @"px;left:" + left + @"px>" + mlabel + @"</label>'); var " + id + @"keypress = 0;
            var " + id + @"Pamt = String('$0');
            $(" + id + @").keyup(function (event) {
                var " + id + @"strout = String('');
                var " + id + @"code = event.keyCode;
                alert(" + id + @"code);
                  switch (" + id + @"code) {
                    case 8:
                        " + id + @"keypress--;
                        if (" + id + @"keypress < 1) {
                            " + id + @"strout = '$0';
                            " + id + @"keypress = 0;
                        }
                        else {
                            switch (" + id + @"keypress) {
                                case 1:
                                    " + id + @"Pamt = '$0.0' + " + id + @"Pamt.substr(3, 1);
                                    break;
                                case 2:
                                    " + id + @"Pamt = '$0.' + " + id + @"Pamt.substr(1, 1) + " + id + @"Pamt.substr(3, 1);
                                    break;
                                default:
                                    " + id + @"Pamt = " + id + @"Pamt.substr(0, " + id + @"Pamt.length - 4) + '.' + " + id + @"Pamt.substr(" + id + @"Pamt.length - 4, 1) + " + id + @"Pamt.substr(" + id + @"Pamt.length - 2, 1);
                                    break;

                            }
                            " + id + @"strout = " + id + @"Pamt;
                        }

                        break;
                    
                    case 46:
                        " + id + @"strout = '$0';
                        " + id + @"keypress = 0;
                        break;

                    case 16:    //shift key

                        break;
                    case 17:    //CTRL key
                        break;
                    case 18:    //ALT key
                        break;

                    default:

                        if (!((" + id + @"code > 47 & " + id + @"code < 58) | (" + id + @"code > 95 & " + id + @"code < 106))) {
                            
                            " + id + @"strout = " + id + @"Pamt;
                        }
                        else {
                            " + id + @"keypress++;
                            if (" + id + @"code > 95) {
                            " + id + @"code = " + id + @"code - 48;
                            }
                            switch (" + id + @"keypress) {
                                case 1:
                                    if (" + id + @"code != 48) {
                                        " + id + @"strout = '$0.0' + String.fromCharCode(" + id + @"code);
                                    }
                                    else {
                                        " + id + @"keypress = 0;
                                        " + id + @"strout = '$0';
                                    }
                                    break;
                                case 2:
                                    " + id + @"strout = '$0.' + " + id + @"Pamt.substr(4, 1) + String.fromCharCode(" + id + @"code);
                                    break;
                                case 3:
                                    " + id + @"strout = '$' + " + id + @"Pamt.substr(3, 1) + '.' + " + id + @"Pamt.substr(4, 1) + String.fromCharCode(" + id + @"code);

                                    break;
                                default:

                                    " + id + @"strout = " + id + @"Pamt.substr(0, " + id + @"Pamt.length - 3) + " + id + @"Pamt.substr(" + id + @"Pamt.length - 2, 1) + '.' + " + id + @"Pamt.substr(" + id + @"Pamt.length - 1, 1) + String.fromCharCode(" + id + @"code);
                                    break;

                            }

                        " + id + @"Pamt = " + id + @"strout;
                    }

                        break;

                }
            $(" + id + @").val(" + id + @"strout);
        });";


            return result;
        }
        public string MakeMoneyInput(string div, string id, string tbclass, string lblclass, string lbltxt)
        {
            string result = "";
            result = @"$(" + div + @").append('<label id=lbl" + id + @" class=" + lblclass + @">" + lbltxt + @"</label><input id=" + id + @" class=" + tbclass + @" value=$0>'); var " + id + @"keypress = 0;
            var " + id + @"Pamt = String('$0');
            $(" + id + @").keyup(function (event) {
                var " + id + @"strout = String('');
                var " + id + @"code = event.keyCode;
                
                  switch (" + id + @"code) {
                    case 8:
                        " + id + @"keypress--;
                        if (" + id + @"keypress < 1) {
                            " + id + @"strout = '$0';
                            " + id + @"keypress = 0;
                        }
                        else {
                            switch (" + id + @"keypress) {
                                case 1:
                                    " + id + @"Pamt = '$0.0' + " + id + @"Pamt.substr(3, 1);
                                    break;
                                case 2:
                                    " + id + @"Pamt = '$0.' + " + id + @"Pamt.substr(1, 1) + " + id + @"Pamt.substr(3, 1);
                                    break;
                                default:
                                    " + id + @"Pamt = " + id + @"Pamt.substr(0, " + id + @"Pamt.length - 4) + '.' + " + id + @"Pamt.substr(" + id + @"Pamt.length - 4, 1) + " + id + @"Pamt.substr(" + id + @"Pamt.length - 2, 1);
                                    break;

                            }
                            " + id + @"strout = " + id + @"Pamt;
                        }

                        break;
                    
                    case 46:
                        " + id + @"strout = '$0';
                        " + id + @"keypress = 0;
                        break;

                    case 16:    //shift key

                        break;
                    case 17:    //CTRL key
                        break;
                    case 18:    //ALT key
                        break;

                    default:

                        if (!((" + id + @"code > 47 & " + id + @"code < 58) | (" + id + @"code > 95 & " + id + @"code < 106))) {
                            
                            " + id + @"strout = " + id + @"Pamt;
                        }
                        else {
                            " + id + @"keypress++;
                            if (" + id + @"code > 95) {
                            " + id + @"code = " + id + @"code - 48;
                            }
                            switch (" + id + @"keypress) {
                                case 1:
                                    if (" + id + @"code != 48) {
                                        " + id + @"strout = '$0.0' + String.fromCharCode(" + id + @"code);
                                    }
                                    else {
                                        " + id + @"keypress = 0;
                                        " + id + @"strout = '$0';
                                    }
                                    break;
                                case 2:
                                    " + id + @"strout = '$0.' + " + id + @"Pamt.substr(4, 1) + String.fromCharCode(" + id + @"code);
                                    break;
                                case 3:
                                    " + id + @"strout = '$' + " + id + @"Pamt.substr(3, 1) + '.' + " + id + @"Pamt.substr(4, 1) + String.fromCharCode(" + id + @"code);

                                    break;
                                default:

                                    " + id + @"strout = " + id + @"Pamt.substr(0, " + id + @"Pamt.length - 3) + " + id + @"Pamt.substr(" + id + @"Pamt.length - 2, 1) + '.' + " + id + @"Pamt.substr(" + id + @"Pamt.length - 1, 1) + String.fromCharCode(" + id + @"code);
                                    break;

                            }

                        " + id + @"Pamt = " + id + @"strout;
                    }

                        break;

                }
            $(" + id + @").val(" + id + @"strout);
        });";


            return result;
        }
        public string MakeRadioList(string div, string id, List<string> items, string itemdefault, int w, int h, int top, int left, int lineup)
        {
            string result = "";
            string listitems = "";
            string defaultvalue = "";

            if (lineup == 1)
            {
                foreach (string I in items)
                {
                    listitems = listitems + @"<label value=" + I.Substring(0, I.IndexOf('♫')) + @" style=position:fixed;display:block;height:" + h + @"px;top:" + (top + 3) + @"px;left:" + (left - I.Substring(0, I.IndexOf('♫')).Length - 35) + @"px;>" + I.Substring(0, I.IndexOf('♫')) + @"</label><input type=radio name=" + id + @" value=" + I.Substring(I.IndexOf('♫') + 1) + @" onclick=" + id + @"clicked(" + I.Substring(I.IndexOf('♫') + 1) + @") ";
                    if (I.Substring(0, I.IndexOf('♫')) == itemdefault) { listitems = listitems + @" checked=checked"; result = result + @" var " + id + @"selected=" + I.Substring(I.IndexOf('♫') + 1) + @"; "; defaultvalue = I.Substring(I.IndexOf('♫') + 1); }
                    listitems = listitems + @" style=position:fixed;display:block;height:" + h + @"px;top:" + top + @"px;left:" + left + @"px></input>";
                    top = top + h + 2;
                }
            }
            else
            {
                foreach (string I in items)
                {
                    listitems = listitems + @"<label value=" + I.Substring(0, I.IndexOf('♫')) + @" style=position:fixed;display:block;height:" + h + @"px;top:" + (top + 3) + @"px;left:" + (left - I.Substring(0, I.IndexOf('♫')).Length - 35) + @"px;>" + I.Substring(0, I.IndexOf('♫')) + @"</label><input type=radio name=" + id + @" value=" + I.Substring(I.IndexOf('♫') + 1) + @" onclick=" + id + @"clicked(" + I.Substring(I.IndexOf('♫') + 1) + @") ";
                    if (I.Substring(0, I.IndexOf('♫')) == itemdefault) { listitems = listitems + @" checked=checked"; result = result + @" var " + id + @"selected=" + I.Substring(I.IndexOf('♫') + 1) + @"; "; defaultvalue = I.Substring(I.IndexOf('♫') + 1); }
                    listitems = listitems + @" style=position:fixed;display:block;height:" + h + @"px;top:" + top + @"px;left:" + left + @"px></input>";
                    left = left + w + 25;
                }
            }

            result = @"$(" + div + @").append('"+listitems+@"'); var "+id+@"selected="+defaultvalue+@"; function "+id+@"clicked(i){"+id+@"selected=i;}";



            return result;

        }
        public string MakeLI(List<string> items)
        {
            return "";
        }
        public string MakeAcctInfo(string div, string id, CustVendEmpInfo info, string Saveto)
        {
            DRCMethods drcmeth = new DRCMethods();
            string F0 = @" ";//$(lblSuite" + id + @").css('left',function(){var WD=$(lblStreet" + id + @").width(); return WD;}); ";
            string F1 = @" function hideEditing" + id + @"(){";
            string F2 = @" function hideLabels" + id + @"(){";
            string F3 = @" function showEditing" + id + @"(){";
            string F4 = @" function showLabels" + id + @"(){";
            //string FEdit = @" function editinfo" + id + @"(){";
            string FSaveEdit = @" $.post('" + Saveto + @"',{AcctID:" + info.CVEAcctID + @",Name:$(tbName" + id + @").val(),ADRStreet:$(tbStreet" + id + @").val(),Suite:$(tbSuite" + id + @").val(),ADRCity:$(tbcity" + id + @").val(),ADRState:$(tbstate" + id + @").val(),ADRZip:$(tbZip" + id + @").val(),ADRCountry:$(tbcountry" + id + @").val(),MainPhone:$(tbPhone" + id + @").val(),PhoneExt:$(tbPhoneExt" + id + @").val(),Fax:$(tbFax" + id + @").val(),Email:$(tbEmail" + id + @").val(),Website:$(tbWebSite" + id + @").val(),Terms:$(tbterms" + id + @").val(),TaxID:selvaltaxloc" + id + @",TaxLoc:$(tbtaxloc" + id + @").val(),Notes:$(taNotes" + id + @").val(),AcctType:" + info.CVEType + @"
            
            });
            showLabels" + id + @"(); hideEditing" + id + @"(); ";

            string FCancelEdit = @"showLabels" + id + @"(); hideEditing" + id + @"();";
            string result = @" document.title='" + info.Name + @"*Information'; ";


            result=result+ MakeLabel("lblInfoName", div, "lblName" + id, drcmeth.fixstring(info.Name)) + MakeInputBox("lbltbInfoName", "tbInfoName", div, "tbName" + id, "Name", "NAME", drcmeth.fixstring(info.Name));
            F1 = F1 + @" $(tbName" + id + @").hide(); ";
            F2 = F2 + @" $(lblName" + id + @").hide(); ";
            F3 = F3 + @" $(tbName" + id + @").show(); ";
            F4 = F4 + @" $(lblName" + id + @").show(); ";


            result = result + @" $(" + div + @").append('<br/>'); ";
            result = result + MakeButton2("btnAcct" + id + @"Edit", div, "", "EDIT", @" hideLabels" + id + @"(); showEditing" + id + @"(); ");

            result = result + MakeButton2("btnAcct" + id + @"Save", div, "", "SAVE", FSaveEdit);
            result = result + MakeButton2("btnAcct" + id + @"Cancel", div, "", "CANCEL",FCancelEdit);
            result = result + @" $(" + div + @").append('<br/>'); ";

            result = result + MakeInputBox("lbltbInfoStreet", "tbInfoStreet", div, "tbStreet" + id, "Street", "STREET: ", info.Street) + MakeLabel("lblInfoStreet", div, "lblStreet" + id, info.Street) + MakeInputBox("lbltbInfoSuite", "tbInfoSuite", div, "tbSuite" + id, "Suite", "SUITE: ", info.Suite) + MakeLabel("lblInfoSuite", div, "lblSuite" + id, info.Suite);
            F1 = F1 + @" $(tbStreet" + id + @").hide(); $(tbSuite" + id + @").hide(); ";
            F2 = F2 + @" $(lblStreet" + id + @").hide(); $(lblSuite" + id + @").hide(); ";
            F3 = F3 + @" $(tbStreet" + id + @").show(); $(tbSuite" + id + @").show(); ";
            F4 = F4 + @" $(lblStreet" + id + @").show(); $(lblSuite" + id + @").show(); ";

            result = result + @" $(" + div + @").append('<br/>'); ";


            result = result + MakeInputPair("lblddlInfoCity", "ddlInfoCity", "tbddlInfoCity", "CITYLIST", div, info.City, "city" + id, "", "CITY: ", "City", 0, 4,"","",true);
            result = result + MakeLabel("lblInfoCity", div, "lblCity" + id, info.City);
            F1 = F1 + @" $(tbcity" + id + @").hide(); $(ddlcity" + id + @").hide(); ";
            F2 = F2 + @" $(lblCity" + id + @").hide(); ";
            F3 = F3 + @" $(tbcity" + id + @").show(); ";//$(ddlcity" + id + @").show(); $(lblddlcity" + id + @").css('left',($(tbSuite" + id + @").width()+$(tbSuite" + id + @").position().left)); ";
            F4 = F4 + @" $(lblCity" + id + @").show(); var WD=60+$(lblSuite" + id + @").position().left; if($(tbSuite" + id + @").val().length>4) {WD=WD-40+$(lblSuite" + id + @").width()}  $(lblCity" + id + @").css('left',WD); $(lblddlcity" + id + @").css('left',WD); ";



            result = result + MakeInputPair("lblddlInfoState", "ddlInfoState", "tbddlInfoState", "STATELIST", div, info.State, "state" + id, "", "STATE: ", "State", 0, 4,"","",true);
            result = result + MakeLabel("lblInfoState", div, "lblState" + id, info.State);

            F1 = F1 + @" $(tbstate" + id + @").hide(); $(ddlstate" + id + @").hide(); ";
            F2 = F2 + @" $(lblState" + id + @").hide(); ";
            F3 = F3 + @" $(tbstate" + id + @").show(); ";//$(ddlstate" + id + @").show(); ";
            F4 = F4 + @" $(lblState" + id + @").show(); ";


            result = result + MakeInputBox("lbltbInfoZip", "tbInfoZip", div, "tbZip" + id, "ZipCode", "ZIPCODE: ", info.Zip) + MakeLabel("lblInfoZip", div, "lblZip" + id, info.Zip);
            F1 = F1 + @" $(tbZip" + id + @").hide(); ";
            F2 = F2 + @" $(lblZip" + id + @").hide(); ";
            F3 = F3 + @" $(tbZip" + id + @").show(); ";
            F4 = F4 + @" $(lblZip" + id + @").show(); ";

            result = result + @" $(" + div + @").append('<br/>'); ";

            result = result + MakeInputPair("lblddlInfoCountry", "ddlInfoCountry", "tbddlInfoCountry", "COUNTRYLIST", div, info.Country, "country" + id, "", "COUNTRY: ", "Country", 0, 4,"","",true);
            result = result + MakeLabel("lblInfoCountry", div, "lblCountry" + id, info.Country);

            F1 = F1 + @" $(tbcountry" + id + @").hide(); $(ddlcountry" + id + @").hide(); ";
            F2 = F2 + @" $(lblCountry" + id + @").hide(); ";
            F3 = F3 + @" $(tbcountry" + id + @").show(); ";
            F4 = F4 + @" $(lblCountry" + id + @").show(); ";

            result = result + @" $(" + div + @").append('<br/>'); ";

            result = result + MakePhoneInput("tbInfoPhone", "lbltbInfoPhone", div, "tbPhone" + id, "Phone", "PHONE: ", info.Phone) + MakeLabel("lblInfoPhone", div, "lblPhone" + id, info.Phone);
            F1 = F1 + @" $(tbPhone" + id + @").hide(); ";
            F2 = F2 + @" $(lblPhone" + id + @").hide(); ";
            F3 = F3 + @" $(tbPhone" + id + @").show(); ";
            F4 = F4 + @" $(lblPhone" + id + @").show(); ";


            result = result + MakeInputBox("lbltbInfoPhoneExt", "tbInfoPhoneExt", div, "tbPhoneExt" + id, "PhoneExtension", "EXT: ", info.PhoneExt) + MakeLabel("lblInfoPhoneExt", div, "lblPhoneExt" + id, info.PhoneExt);
            F1 = F1 + @" $(tbPhoneExt" + id + @").hide(); ";
            F2 = F2 + @" $(lblPhoneExt" + id + @").hide(); ";
            F3 = F3 + @" $(tbPhoneExt" + id + @").show(); ";
            F4 = F4 + @" $(lblPhoneExt" + id + @").show(); ";

            result = result + MakePhoneInput("tbInfoFax", "lbltbInfoFax", div, "tbFax" + id, "Fax", "FAX: ", info.Fax) + MakeLabel("lblInfoFax", div, "lblFax" + id, info.Fax);
            F1 = F1 + @" $(tbFax" + id + @").hide(); ";
            F2 = F2 + @" $(lblFax" + id + @").hide(); ";
            F3 = F3 + @" $(tbFax" + id + @").show(); ";
            F4 = F4 + @" $(lblFax" + id + @").show(); ";


            result = result + MakeInputBox("lbltbInfoEmail", "tbInfoEmail", div, "tbEmail" + id, "Email", "MAIN EMAIL: ", info.Email) + MakeLabel("lblInfoEmail", div, "lblEmail" + id, info.Email);
            F1 = F1 + @" $(tbEmail" + id + @").hide(); ";
            F2 = F2 + @" $(lblEmail" + id + @").hide(); ";
            F3 = F3 + @" $(tbEmail" + id + @").show(); ";
            F4 = F4 + @" $(lblEmail" + id + @").show(); ";

            result = result + @" $(" + div + @").append('<br/>'); ";

            result = result + MakeInputBox("lbltbInfoWebSite", "tbInfoWebSite", div, "tbWebSite" + id, "WebSite", "WEBSITE: ", info.Website) + MakeAnchor("aInfoWebSite", div, "aWebSite" + id, info.Website);
            F1 = F1 + @" $(tbWebSite" + id + @").hide(); ";
            F2 = F2 + @" $(aWebSite" + id + @").hide(); ";
            F3 = F3 + @" $(tbWebSite" + id + @").show(); ";
            F4 = F4 + @" $(aWebSite" + id + @").show(); ";

            result = result + @" $(" + div + @").append('<br/>'); ";

            result = result + MakeInputPair("lblddlInfoTerms", "ddlInfoTerms", "tbddlInfoTerms", "TERMSLIST", div, info.Terms, "terms" + id, "", "TERMS: ", "Terms", 0, 4,"","",true);
            result = result + MakeLabel("lblInfoTerms", div, "lblTerms" + id, info.Terms);
            F1 = F1 + @" $(tbterms" + id + @").hide(); $(ddlterms" + id + @").hide(); ";
            F2 = F2 + @" $(lblTerms" + id + @").hide(); ";
            F3 = F3 + @" $(tbterms" + id + @").show(); ";
            F4 = F4 + @" $(lblTerms" + id + @").show(); ";

            result = result + MakeInputPair("lblddlInfoTaxLoc", "ddlInfoTaxLoc", "tbddlInfoTaxLoc", "TAXLOCLIST", div, info.TaxLocation, "taxloc" + id, "", "TAX LOCATION: ", "Tax_Location", 1, 4,"","",true);
            result = result + MakeLabel("lblInfoTaxLoc", div, "lblTaxLoc" + id, info.TaxLocation);
            F1 = F1 + @" $(tbtaxloc" + id + @").hide(); $(ddltaxloc" + id + @").hide(); ";
            F2 = F2 + @" $(lblTaxLoc" + id + @").hide(); ";
            F3 = F3 + @" $(tbtaxloc" + id + @").show(); ";
            F4 = F4 + @" $(lblTaxLoc" + id + @").show(); ";

            result = result + @" $(" + div + @").append('<br/>'); ";

            result = result + MakeLabel("lblInfoNotes", div, "lblNotes" + id, info.Notes);
            result = result + MakeTextArea("lbltaInfoNotes", "taInfoNotes", div, "taNotes" + id, "Notes", "NOTES: ", info.Notes, 1, 7);
            F1 = F1 + @" $(taNotes" + id + @").hide(); ";
            F2 = F2 + @" $(lblNotes" + id + @").hide(); ";
            F3 = F3 + @" $(taNotes" + id + @").show(); ";
            F4 = F4 + @" $(lblNotes" + id + @").show(); ";

            

            //Set Visibility

            F1 = F1 + @" $(btnAcct" + id + @"Save).hide(); $(btnAcct" + id + @"Cancel).hide();} ";
            F2 = F2 + @" $(btnAcct" + id + @"Edit).hide();} ";
            F3 = F3 + @" $(btnAcct" + id + @"Save).show(); $(btnAcct" + id + @"Cancel).show(); $(" + div + @").removeClass('InfoView'); $(" + div + @").addClass('InfoEdit');} ";
            F4 = F4 + @" $(btnAcct" + id + @"Edit).show(); $(" + div + @").removeClass('InfoEdit'); $(" + div + @").addClass('InfoView'); } ";
          //  FEdit = FEdit + @" hideLabels" + id + @"(); showEditing" + id + @"();} ";
            
            

            result = result + @"

" + F0 + @"

" + F1 + @"


" + F2 + @"


" + F3 + @"


" + F4;
            if (info.CVEAcctID > 0)
            {
                result = result + @" hideEditing" + id + @"(); $(" + div + @").show(); showLabels" + id + @"(); ";

                result = result + @" $(tbName" + id + @").hide(); $(lbltbName" + id + @").hide(); $(tbName" + id + @").val('" + info.Name + @"'); ";

            }
            else
            {
                result = result + @" hideLabels" + id + @"(); $(" + div + @").addClass('InfoEdit'); $(" + div + @").show(); ";
            }
            return result;
        }
        //public string MakeCustDDLs(int AcctID)
        //{
        //    string result = "";

        //    result = result + MakeInputPair("AcctInfoDDLlbl", "AcctInfoDDL", "AcctInfoDDLTB", "EQUIP", "divCustDDLs", "", "Equipment", AcctID.ToString(), "Equipment:", "Customer_Equipment_Records", 1, 10, @" window.open('/DRCCustomer/LoadEquipment/?EquipID='+selvalEquipment); ", @" window.open('/DRCCustomer/LoadEquipment/?EquipID='+selvalEquipment); ", true);
        //    result = result + MakeButton2(@"btnNewPassWrd", "divCustDDLs", "btnclass", "NEW EQUIPMENT", @"$.post('/DRCCustomer/NewEquipment',{AcctID:AcctID}); $(divnewEquipment).show(); ");
        //    //result = result + MakeInputPair(@"JobLogDetEquiplbl", "JobLogDetEquipddl", "JobLogDetEquiptb", "EQUIP", div, "", id + "list", AcctID.ToString(), "Customer Equipment:", "CustomerEquipment", 0, 10, @" $.post('/DRCCustomer/AddEquipmenttoJob',{EquipID:selval" + id + @"list,JobID:JobID}); ", @" $.post('/DRCCustomer/AddEquipmenttoJob',{EquipID:selval" + id + @"list,JobID:JobID}); ", true);

        //    return result;
        //}
        public string FunctDDLSelected(string ddlname,string functioncase)
        {
            string result = @" $(" + ddlname + @").change(function ("+ddlname+@"event) { ";
            


            switch (functioncase)
            {
                case "VendSelected":
                    result = result + @" window.open('/DRCVendor/Vendinfo/?AcctID='+$(this).val()); ";
                    break;
                case "CustSelected":
                    result = result + @" window.open('/DRCCustomer/CustInfo/?AcctID='+$(this).val()); ";
                    break;
                case "InvWHSelected":
                    result = result + @" $(btnWHDetails).show(); $.post('/DRCInventory/AddLocations', {AcctID:$(this).val()});
";
                    break;
                case "InvBldgSelected":
                    result = result + @" $(btnBldgDetails).show(); ";
                    break;
                case "InvRoomSelected":
                    result = result + @" $(btnRoomDetails).show(); ";
                    break;
                case "InvBinSelected":
                    result = result + @" $(btnBinDetails).show(); ";
                    break;
            }
            result = result + @" }); ";
            return result;
        }
        public string FunctionTBKeyUp(string TBName, string functioncase)
        {
            string result = @" $(" + TBName + @").keyup(function (" + TBName + @"event) {";
            switch (functioncase)
            {
                case "InvWHTB":
                    result = result + @" if(!(document.getElementById('ddlstkWareHouse').selectedIndex>-1)) {$(btnWHDetails).hide();} else{$(btnWHDetails).show();} ";
                    break;
                case "InvBldgTB":
                    result = result + @" if(!(document.getElementById('ddlstkbuilding').selectedIndex>-1)) {$(btnBldgDetails).hide();} else{$(btnBldgDetails).show();} ";
                    break;
                case "InvRoomTB":
                    result = result + @" if(!(document.getElementById('ddlstkroom').selectedIndex>-1)) {$(btnRoomDetails).hide();} else{$(btnRoomDetails).show();} ";
                    break;
                case "InvBinTB":
                    result = result + @" if(!(document.getElementById('ddlstkbin').selectedIndex>-1)) {$(btnBinDetails).hide();} else{$(btnBinDetails).show();} ";
                    break;
            }
            result = result + @" }); ";
            return result;
        }
        public string MakeTablePages(string type,string div, string tblclass,string id,string caption,string css, int columns, int rows, int pagesize,int filter)
        {
            string result = @"$("+div+@").empty(); $(" + div + @").append('<table id=" + id + @">";
            string thead = @"<thead>";
            string trows = @"";
            string btnfunction=@" $(" + div + ").empty(); ";
            caption = @"<caption>" + caption + @"</caption>";
            string casespecific = "";
            switch (type)
            {
                case "Jobs":
                    
                    break;
                case "Passwords":
                    List <Passcodes> CP = DRCrepos.getPasswords(filter);
                    if (CP.Count > 0)
                    {
                        thead = thead + @"<th>EntityType</th><th>Name</th><th>UserName</th><th>Password</th><th>Device</th></thead>";
                        foreach (Passcodes P in CP)
                        {
                            trows = trows + @"<tr><td>" + P.EntityType + @"</td><td>" + P.EntityName + @"</td><td>" + P.Username + @"</td><td>" + P.Pass + @"</td><td>"+DRCrepos.getEquipmentNamefromID(P.DeviceID)+@"</td></tr>";
                        }

                    }
                    else
                    {
                        thead = thead + "<th>No Data Found</th></thead>";
                        caption = "";
                    }
                    
                    btnfunction = btnfunction + @" $(divCustomerInfo).show(); $(btnCustData).hide(); $(btnCustData).show(); ";
                  //  casespecific = @" $(btnAddPass).click(function () { $.post('/DRCCustomer/NewPass',{AcctID:PCustID,TableName:"+id+@"});}); ";
                    break;

                case "Accounts":


                    break;


                default:
                    break;
            }

            result = result+caption +thead+trows+ @"</table>'); ";
            result = result + MakeButton2(@"btnClose" + id, div,"btnclass", "CLOSE",btnfunction )+casespecific;
            return result;
        }


        public string MakeTable(string div, string id,Array data,bool hsplit,string summary)
    {
            //css classes
            //rows and columns start with odd class
            //id+roweven=even row class id+rowodd=odd row class id+rowheader=header row class id+colheader=header column class id+coleven=even column class id+colodd=odd column class
            //identities
            //id=table id+row+int++=row id+col+int++=colomn

        DRCMethods DRCMeth = new DRCMethods();
        string result = @"$("+div+@").append('<button id="+id+@"btnremove>CLOSE</button></br><table id="+id+@" summary="+summary+@">";
        int row = 0;
        string rowclass = id + "rowodd";
        string colclass = id + "colodd";
        foreach (var item in data)
        {
            PropertyInfo[] propi=item.GetType().GetProperties();

           if (row == 0)//build header
           {
               int s = propi.Length / 2;//Dont know what happens with an odd amount of columns
               result = result + @"<tr id="+id+@"row" + row + @" class="+id+@"rowheader>";
               int hcol = 0;
               foreach (PropertyInfo h in propi)
               {
                   result = result + @"<th id="+id+@"col"+row+@" class="+id+@"colheader"+hcol+@">" + h.Name + @"</th>";
                   hcol++;
               }
           }
           row++;
           result = result + @"<tr id="+id+@"row"+row+@" class="+rowclass+@">";
           if (rowclass == id + "rowodd") rowclass = id + "roweven";
           else rowclass = id + "rowodd";
           int column = 0;
           foreach (PropertyInfo col in propi)
           {
               try//catch null values
               {
                   result = result + @"<td id="+id+@"col" + column + @" class="+colclass+@">" + DRCMeth.fixstring(col.GetValue(item, null).ToString()) + @"</td>";
               }
               catch
               {
                   result = result + @"<td id=col" + column + @"  class=" + colclass + @">" + col.GetValue(item, null) + @"</td>";
               }
               if (colclass == id + "colodd") colclass = id + "coleven";
               else colclass = id + "colodd";
               column++;
           }
           result = result + @"</tr>";
        }

        result = result + @"</table>'); $(" + id + @"btnremove).click(function(){$(divAllCustList).empty()}); ";
        return result;

    }

        public string MakeAccountList(int typeID)
        {
            string result = "";
            string summary="";
            switch (typeID)
            {
                case 9:
                    summary=@"Viewing all active and inactive customers";
                    break;
                default:
                    break;
            }
            List<Account> AllAccts = DRCrepos.AccountList(typeID);
            List<DRC_AccountInfoTable> AllInfo = new List<DRC_AccountInfoTable>();
            List<Array> AllAccounts=new List<Array>();
            List<AccountList> AcctList = new List<AccountList>();
            foreach (Account item in AllAccts)
            {
                Array test = item.GetType().GetProperties().ToArray();
                AccountList AL = new AccountList();
                AL.AcctID = item.AccountID; AL.Name = item.Name; AL.Terms = item.Terms;
                int infoid = DRCrepos.getAcctInfoID(item.AccountID);
                DRC_AccountInfoTable AI = new DRC_AccountInfoTable();
                AI = DRCrepos.getAcctInfo(infoid);
                AL.City = AI.BusinessAddressCity; AL.Country = AI.BusinessAddressCountry; AL.Fax = AI.BusinessFaxNumber;  AL.MainEmail = AI.EmailAddress1; AL.Phone = AI.BusinessTelephoneNumber; AL.PhoneExt = AI.PhoneExtension; AL.State = AI.BusinessAddressState; AL.StreetAddress = AI.BusinessAddressStreet; AL.Suite = AI.BusinessAddressSuite; AL.TaxCode = Convert.ToInt32(AI.TaxCode); AL.TaxLocation = AI.TaxLocation; AL.WebPage = AI.WebPage; AL.ZipCode = AI.BusinessAddressPostalCode;
                AcctList.Add(AL);
            }
            Array AcctL = AcctList.ToArray();
            result = MakeTable("divAllCustList", "tblCustList", AcctL,true,summary);

            return result;
        }

        
        public string MakeJobNewEditDetails(string div, int JobNum, int AcctID, string id)
        {
            
            DRCMethods drcmeth = new DRCMethods();
            //if (JobNum > 0) AcctID = DRCrepos.getAcctIDfromJobID(JobNum);
            string result = @" var AID=" + AcctID + @"; var JN=" + JobNum + @"; var completed='false'; ";

            string actions = @"
                                function CancelJobReq(){
                                    $(" + div + @").hide();
                                    $("+div+ @").empty();
                                    $(btnNewJob).show();
                                    $(btnNewJob).show();
                                    $(btnViewCompleted).show();
                                    $(btnViewIncomplete).show();
                                    $(divJobLogs).empty();
                                    $(btnNewJobLog).hide();
                                    $(btnDeleteJob).hide();
                                    $(divEquipment).empty();
                                    
                                    $(divJobDetails).empty();
                                    
                                } 


                            ";
            string Save = @" if(selvalcustcontact==0){$.post('/DRCCustomer/QuickContact', {contactname:$(CONTACTScust).val(), AcctID:" + AcctID + @"}); }
                            else {$.post('/DRCCustomer/SaveJob', {jobid:JN, CustID:AID, tech:selvaltech, status:selvalstatus, descript:$(JobDescript).val(), ReqDate:$(jobreqdate).val(),  CompDate:$(jobcompdate).val(), SR:Ratingvar, Pri:Priorityvar, Requestor:selvalcustcontact,EstimateRequired:document.getElementById('" + id + @"JobEstReqcb').checked,laborest:$("+id +@"LbrEst).val(),partest:$("+id + @"PrtEst).val(),}); CancelJobReq();} ";
            string Cancel = @" CancelJobReq(); ";

            string ViewLogs = @" $.post('/DRCCustomer/LogList',{JobID:JN}); ";
            


            int OSRDefault = 53;
            int StatusDefault = 25;
            int PriorityDefault = 14;
            int ServTypeDefault = 37;
            string JobHeader = "";
           
            JobRequest J = new JobRequest();
            J.AuthorizedAmount = 0; J.AuthorizedBy = 0; J.ChargesAuthorized = false; J.Completed = false; J.CreatedBy = drcmeth.DRCuser(); J.CustID = AcctID; J.Description = ""; J.EstimateRequested = false; J.JobNumber = 0; J.LaborEstimate = 0; J.PartsEstimate = 0; J.Priority = PriorityDefault; J.SatisfactionRating = OSRDefault; J.Status = StatusDefault; J.RequestDate = DateTime.Now; J.DispatchOnsite = true; J.ServiceType = ServTypeDefault;

            string CompanyName=drcmeth.fixstring(DRCrepos.getAcctNamefromID(AcctID));
            if (JobNum > 0)
            {
                J = DRCrepos.getSingleJobRequest(JobNum);
                JobHeader = @"Viewing job#" + JobNum;
            }
            else JobHeader = @"Creating New Job";
          //  if (Convert.ToBoolean(J.EstimateRequested)) actions = actions + @" $(" + id + @"JobEstReqcb).show(); ";
            //   else actions = actions + @" $(" + id + @"JobEstReqcb).hide(); ";

            #region MAIN HHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH

            result = result + MakeButton2("btnViewLogs", "divControls", "btnclass", "ViewLogs", ViewLogs);
            result = result + MakeButton2("SaveNewRequest", "divControls", "SaveBtn", "SAVE", Save);
            result = result + MakeButton2("CancelNewRequest", "divControls", "CancelBtn", "CLOSE", Cancel);
                result = result + @" $(" + div + @").append('</br>'); ";

                
                result = result + IE.MakeLabel("JobPageHeader", div, "lblPageHeader", JobHeader);
                result = result + @" $(" + div + @").append('</br>'); ";
                result = result + MakeLabel("JobPageHeader", div, "CustName", CompanyName);
               
                result = result + @"$(" + div + @").append('</br>'); ";

                result = result + IE.MakeCheckbox("JobCheckBox", "JobCheckBox", div, "Job_Complete", "", false,true);
                result = result + MakeLabel("JobLabel", div, "lblJobComplete", @"Completed");
                result = result + @" $(" + div + @").append('</br>'); ";
                result = result + MakeLabel("JobLabel", div, "ReqDatelbl", @"Request Date: ");
                result = result + MakeDateField("JobDates", div, "jobreqdate",J.RequestDate.Value.ToShortDateString() );
                
                result = result + MakeLabel("JobLabel", div, "CompDatelbl", @"Completion Date: ");
                
                string completedate = "";
                try { completedate = J.DateCompleted.Value.ToShortDateString(); }
                catch {  }//leaves the date blank
                result = result + MakeDateField("JobDates", div, "jobcompdate", completedate);
                result = result + @"$(" + div + @").append('</br>'); ";

                string ddlpairclass = "'background-color':'Aqua','border-style':'none','font-size':'20px','color':'#5C87B2','overflow':'visible'";
                string SUBddlpairclass = "'background-color':'Aqua','border-style':'none','font-size':'20px','color':'#5C87B2','overflow':'visible'";
                string tbpairclass = "'background-color':'transparent','border-style':'none','font-size':'20px','color':'black'";

                result = result + MakeLabel("JobLabel", div, "lblRequestBy", @"Requester: ");
                string requestedby = "";
                try { requestedby = J.RequestedBy.Value.ToString(); }
                catch { }
                result = result + IE.MakeInputPair("CONTACTS", div, requestedby, "CONTACTScust__"+AcctID.ToString(), tbpairclass, ddlpairclass, SUBddlpairclass, AcctID.ToString(), "Requester", 1, 10, "", "", true);
                result = result + @"$(" + div + @").append('</br>'); tbAdjustWidth(CONTACTScust__"+AcctID.ToString()+@");  ";
              result = result + MakeLabel("JobLabel", div, "lblAssignedTech", @"Assigned Tech: ");
              string assignedtech = "";
              try { assignedtech = J.AsignedTech.Value.ToString(); }
              catch { }
              result = result + IE.MakeInputPair("CONTACTS", div, assignedtech, "CONTACTStech__13", tbpairclass, ddlpairclass, SUBddlpairclass, "13", "Assigned_Service_Rep", 1, 10, "", "", true);
              result = result + @" tbAdjustWidth(CONTACTStech__13);  ";
                result = result + @"$(" + div + @").append('</br>'); ";
                result = result + MakeLabel("JobLabel", div, "lblStatus", @"Status: ");
                result = result + IE.MakeInputPair("JOBCODES", div, J.Status.ToString(), "JOBCODESstatus__1", tbpairclass, ddlpairclass, SUBddlpairclass, "1", "Job_Status", 1, 10, "", "", true);
                result = result + @" tbAdjustWidth(JOBCODESstatus__1);  ";
            
            result = result + MakeLabel("JobLabel", div, "lblPriority", @"Priority: ");
            result = result + IE.MakeInputPair("JOBCODES", div, J.Priority.ToString(), "JOBCODESpriority__3", tbpairclass, ddlpairclass, SUBddlpairclass, "3", "Job_Priority", 1, 10, "", "", true);
            result = result + @" tbAdjustWidth(JOBCODESpriority__3);  ";

            result = result + MakeLabel("JobLabel", div, "lblOveralSatisfaction", @"Satisfaction Rating: ");
            result = result + IE.MakeInputPair("JOBCODES", div, J.SatisfactionRating.ToString(), "JOBCODESsatisfaction__5", tbpairclass, ddlpairclass, SUBddlpairclass, "5", "Job_Priority", 1, 10, "", "", true);
            result = result + @" tbAdjustWidth(JOBCODESsatisfaction__5);  ";

            #endregion
            result = result + @"$(" + div + @").append('</br>'); ";
            result = result + @"$(" + div + @").append('</br>'); ";

                #region Estimate Section HHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH

            string TotalEstimate = @" $(JobReqEstTotal).val('$'+(Number($(LbrEst).val().substr(1))+Number($(PrtEst).val().substr(1)))); ";// var JRLE=$(tb" + id + @"LbrEst).val(); var JRPE=$(tb" + id + @"PrtEst).val();  $(" + id + @"JobReqEstTotal).val(JRLE+JRPE); ";



            string toggleestimate = @" $(lblEstimate).toggle(); $(JobEstReqcb).toggle(); $(LbrEst).toggle(); $(PrtEst).toggle(); $(JobReqEstTotal).toggle(); $(btnCalcEst).toggle(); $(cbEstimateAuthorized).toggle(); $(lblcbAuthorized).toggle(); $(lblAuthorizedAmount).toggle(); $(tbAuthorizedAmount).toggle(); $(AuthorizedBy).toggle(); $(ddlAuthorizedBy).toggle(); $(lblAuthorizedBy).toggle(); ";
        result=result+IE.MakeButton("btnEstimate", "divControls", "btnclass", "ESTIMATE", toggleestimate,false);
            
            result = result + MakeLabel("JobReqDetSectionHead", div, "lblEstimate", @"ESTIMATE");
            
            result = result + IE.MakeCheckbox("JobEstReqcb", "BIGCB", div, "Estimate_Required", "", Convert.ToBoolean(J.EstimateRequested),false);
            result = result + @"$(" + div + @").append('</br>'); ";
            result = result + @"$(" + div + @").append('</br>'); ";
            
            result = result + IE.MakeMoneyInput(div, "LbrEst", "tbclass","Labor_Estimate", J.LaborEstimate.ToString());
            result = result + IE.MakeMoneyInput(div, "PrtEst", "tbclass", "Parts_Estimate", J.PartsEstimate.ToString());


            result = result + @"$(" + div + @").append('</br>'); ";
            result = result + IE.MakeMoneyInput(div, "JobReqEstTotal", "tbclass", "Total_Estimate", (J.PartsEstimate+J.LaborEstimate).ToString());
            
        result=result+IE.MakeButton("btnCalcEst", div, "btnclass", "$", TotalEstimate,false);
                
                result = result + @"$("+div+@").append('</br>'); ";
                
                result = result + IE.MakeCheckbox("cbEstimateAuthorized", "cbclass", div, "Estimate_Authorized", "", false,false);
                result = result + MakeLabel("labelclass", div, "lblcbAuthorized", @"AmountAuthorized");
                result = result + @"$(" + div + @").append('</br>'); ";
                result = result + MakeLabel("labelclass", div, "lblAuthorizedAmount", @"Authorized Amount: ");
                result = result + IE.MakeMoneyInput(div, "tbAuthorizedAmount", "tbclass", "Authorized_Amount", J.AuthorizedAmount.Value.ToString());
                result = result + MakeLabel("labelclass", div, "lblAuthorizedBy", @"Authorizing Contact: ");
                result = result + IE.MakeInputPair("CONTACTS", div, J.AuthorizedBy.ToString(), "AuthorizedBy", tbpairclass, ddlpairclass, SUBddlpairclass, AcctID.ToString(), " ", 1, 10, "alert('option selected');", "alert('suboption selected');", false);
                result = result + @" tbAdjustWidth(AuthorizedBy);  ";
                #endregion

                #region Equipment Section HHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH
                result = result + @"$(" + div + @").append('</br>'); ";
                result = result + @"$(" + div + @").append('</br>'); ";
                result = result + MakeLabel("JobReqDetSectionHead", div, "lblEquipment", @"EQUIPMENT");
                result = result + @"$(" + div + @").append('</br>'); ";
                result = result + @"$(" + div + @").append('</br>'); ";

                result = result + IE.MakeInputPair("DEVICE", div, "", "EquipmentList", tbpairclass, ddlpairclass, SUBddlpairclass, AcctID.ToString(), "Equipment_List", 1, 10, @" $.post('/DRCCustomer/AddEquipmenttoJob',{EquipID:selvalEquipmentList,JobID:JobID}); ", @" $.post('/DRCCustomer/AddEquipmenttoJob',{EquipID:selval" + id + @"list,JobID:JobID}); ", false);
                result = result + @" tbAdjustWidth(EquipmentList);  ";
                string NewEquipmentClick = @" alert('button clicked!'); ";
                result = result + IE.MakeButton("btnNewEquipment", div, "btnclass", "NEW EQUIPMENT", NewEquipmentClick, false);

                string SaveEquipment = @"     
                                if(selvalequipmentmanmodelist<1)
                                { 
                                   alert($(tb" + id + @"manmodelist).val());
                                    $.post('/DRCCustomer/NewManCode',{CodeName:$(tb" + id + @"manmodelist).val()}); 
                                    $.post('/DRCCustomer/QuickEquipmentSave',{Manufact:selvalequipmentmanmodelist, ModelID:selvalDequipmentmanmodelist,SN:$(equipmentEQsn).val(), DeviceType:selvalequipmenttypelist, CustID:AcctID, Name:$(equipmentEQName).val()});
                         }
                                else
                                    {$.post('/DRCCustomer/QuickEquipmentSave',{Manufact:selvalequipmentmanmodelist, ModelID:selvalDequipmentmanmodelist,SN:$(equipmentEQsn).val(), DeviceType:selvalequipmenttypelist, CustID:AcctID, Name:$(equipmentEQName).val()});}
                                $(" + div + @").hide(); $(equipmentEQsn).val(''); $(equipmentEQName).val('');


                             ";
                result = result + IE.MakeButton("btnSaveNewEquipment", div, "btnclass", "SAVE NEW EQUIPMENT", SaveEquipment, false);

                string CancelEquipment = @"$(" + div + @").hide(); $(equipmentEQsn).val(''); $(equipmentEQName).val(''); ";
                result = result + IE.MakeButton("btnCancelEquipment", div, "btnclass", "CANCEL NEW EQUIPMENT", CancelEquipment, false);


                result = result + MakeJobLogEquipTable(div, "tblEquipment", AcctID, JobNum, 0);

                string toggleEquipment = @" $(ddlEquipmentList).toggle(); $(EquipmentList).toggle(); $(btnNewEquipment).toggle(); $(lblEquipment).toggle(); $(btnCancelEquipment).toggle(); $(btnSaveNewEquipment).toggle(); $(tblEquipment).toggle(); $(EQName).toggle(); $(lblEQName).toggle(); $(ddlEquiptypelist).toggle(); $(Equiptypelist).toggle(); $(EQsn).toggle(); $(ddlManList).toggle(); $(ManList).toggle(); $(ddlModelList).toggle(); $(ModelList).toggle(); ";

            result = result + IE.MakeButton("btnEquipment", "divControls", "btnclass", "EQUIPMENT", toggleEquipment, false);

                string EquipName = "";
                string SN = "";




            result = result + MakeInputBox("lblEQName", "tbEQName", div, "EQName", "Equipment_Name", "Name:", EquipName);

            result = result + IE.MakeInputPair(@"DEVICETYPES", div, "", "Equiptypelist", "", "", "", AcctID.ToString(), "Equipment_Type", 0, 10, "", "", false);
            result = result + @" tbAdjustWidth(Equiptypelist);  ";
            string ManCodeClick = @" $.post('/DRCCustomer/SMM',{ManCode:selvalManList}); ";

            result = result + IE.MakeInputPair("MANCODES", div, "", "ManList", tbpairclass, ddlpairclass, SUBddlpairclass, "", "Manufacturer_List", 1, 10, ManCodeClick, ManCodeClick, false);
            result = result + @" tbAdjustWidth(ManList);  ";
            result = result + IE.MakeInputPair("MODELS", div, "", "ModelList", tbpairclass, ddlpairclass, SUBddlpairclass, "0", "Model_List", 1, 10, "alert('option selected');", "alert('suboption selected');", false);
            result = result + @" tbAdjustWidth(ModelList);  ";
            result = result + @"$(" + div + @").append('</br>'); ";
            result = result + MakeInputBox("lblEQsn", "tbEQsn", div, "EQsn", "Serial_Number", "Serial Number:", SN);

                #endregion

                result = result + @"$(" + div + @").append('</br>'); ";
                result = result + MakeTextArea("JobReqDetDesclbl", "JobReqDetDescbox", div, "JobDescript", "Job_Description", "Request: ",drcmeth.fixstring(J.Description), 1, 6);



                actions = actions + @" $(lblJobComplete).addClass('JobReqDetCells'); $(ReqDatelbl).addClass('JobReqDetCells'); $(CompDatelbl).addClass('JobReqDetCells');  $(document).ready(function(){" + toggleestimate +toggleEquipment+ @" }); ";

            return result + actions+JF.tbAdjustWidth()+JF.InputPairFunctions();
        }     
        public string MakeJobEquipment(string div, string id, int AcctID, int JobID)
        {
            string result = "";

            result = result + @"$(" + div + @").append('</br>'); $(divnewEquipment).hide(); ";
            //result = result + MakeLabel("LogFirstOnLine", div, id + "Title", "EQUIPMENT:");
            result = result + @"$(" + div + @").append('</br>'); ";

            if (JobID > 0)
            {

            }
            else
            {

            }

            result = result + MakeInputPair(@"JobLogDetEquiplbl", "JobLogDetEquipddl", "JobLogDetEquiptb", "EQUIP", div, "", id + "list", AcctID.ToString(), "Customer Equipment:", "CustomerEquipment", 0, 10, @" $.post('/DRCCustomer/AddEquipmenttoJob',{EquipID:selval" + id + @"list,JobID:JobID}); ", @" $.post('/DRCCustomer/AddEquipmenttoJob',{EquipID:selval" + id + @"list,JobID:JobID}); ", true);


            
            result = result + MakeButton2(id + "newEquip", div, "JobDetAddEquipBtn", "New Equipment", @" $(divnewEquipment).toggle(); ");


            result = result + MakeJobLogEquipTable(div, "tblEquipment", AcctID, JobID, 0);
            result = result + MakeQuickEquipment(AcctID);
            return result;
        }
        
        public string MakeJobLogTravel(string div, string id, int LogID)
        {
            string result = "";
            result = result + @"$(" + div + @").append('</br>'); ";
            result = result + MakeLabel("LogFirstOnLine", div, id + "TravelLabel", "TRAVEL DATA:");
            result = result + @"$(" + div + @").append('</br>'); ";
            result = result + MakeInputBox("depotdepartlbl", "JobLogDetTimetb", div, id + "depotdeparttime", "DepotDepartTime", "DepotDepartTime:", "");
            result = result + MakeInputBox("jobsitearrivallbl", "JobLogDetTimetb", div, id + "jobsitearrivaltime", "JobSiteArrivalTime", "JobSiteArrivalTime:", "");
            result = result + @"$(" + div + @").append('</br>'); ";
            result = result + MakeInputBox("LogFirstOnLine", "JobLogDetTimetb", div, id + "jobsitedeparttime", "JobSiteDepartTime", "JobSiteDepartTime:", "");
            result = result + MakeInputBox("depotarrivallbl", "JobLogDetTimetb", div, id + "depotarrivaltime", "DepotArrivalTime", "DepotArrivalTime:", "");
            result = result + @"$(" + div + @").append('</br>'); ";
            result = result + MakeInputBox("traveltimeWKlbl", "traveltimetb", div, id + "totaltraveltime", "TotalTravelTime", "TotalTravelTime:", "");
            result = result + MakeInputBox("traveltimeBLDlbl", "traveltimetb", div, id + "traveltimebilled", "TravelTimeBilled", "TravelTimeBilled:", "");
            result = result + @"$(" + div + @").append('</br>'); ";
            result = result + MakeInputBox("OdometerSlbl", "Odometertb", div, id + "odstart", "OdometerStart", "OdometerStart:", "");
            result = result + MakeInputBox("OdometerElbl", "Odometertb", div, id + "odend", "OdometerEnd", "OdometerEnd:", "");
            result = result + MakeInputBox("TotalMlbl", "TotalMtb", div, id + "totalmiles", "TotalMiles", "TotalMiles:", "");

            return result;
        }
        public string MakeJobLogParts(string div, string id, int LogID)
        {
            string result = "";



            return result;
        }
        public string MakeJobLogDetails(string div, int JobNum, string id, int AcctID, int LogID)
        {
            string result = "";

            string actions = @" $(" + div + @").show(); ";

            string Save = @" $.post('/DRCCustomer/SaveJob', {jobid:JN, CustID:AID, tech:selvaltech, status:selvalstatus, descript:$(JobDescript).val(), ReqDate:$(jobreqdate).val(), complete:'false', CompDate:$(jobcompdate).val(), SR:Ratingvar, Pri:Priorityvar, Requestor:selvalcustcontact}); window.close(); ";
            string Cancel = @" window.close(); ";
            #region JobLog Field Construction
            result = result + MakeLabel("LogTitleLabel", div, id + "main", @"Adding manual log entry for job #" + JobNum + @"   ");
            result = result + @"$(" + div + @").append('</br>'); ";
            result = result + MakeButton2("SaveNewLog", div, "SaveBtn", "SAVE", Save);
            result = result + MakeButton2("CancelNewLog", div, "CancelBtn", "CANCEL", Cancel);
            result = result + @"$(" + div + @").append('</br></br>'); ";
            result = result + MakeLabel("LogFirstOnLine", div, id + "date", @"Log Date:");
            result = result + MakeDateField("LogDate", div, id + "logdate", DateTime.Now.ToShortDateString());
            result = result + MakeInputPair(@"JobLogDetServiceTypelbl", "JobLogDetServiceTypeddl", "JobLogDetServiceTypetb", "JOBCODE", div, "", id + "servicetype", "2", "Service Type:", "ServiceType", 0, 10, "", "",true);
            result = result + @"$(" + div + @").append('</br>'); ";
            result = result + MakeInputBox("LogFirstOnLine", "JobLogDetTimetb", div, id + "timein", "TimeIn", "Time In:", DateTime.Now.ToLocalTime().ToShortTimeString());
            result = result + MakeInputBox("JobLogDetTimelbl", "JobLogDetTimetb", div, id + "timeout", "Time Out", "TimeOut:", DateTime.Now.ToLocalTime().ToShortTimeString());
            result = result + MakeInputBox("JobLogDetWKHourlbl", "JobLogDetWKHourtb", div, id + "workhours", "WorkHours", "Work Hours:", "");
            result = result + MakeInputBox("JobLogDetBLDHourlbl", "JobLogDetBLDHourtb", div, id + "billedhours", "BilledHours", "Billed Hours:", "");
            result = result + @"$(" + div + @").append('</br>'); ";
            result = result + MakeInputBox("LogFirstOnLine", "JobLogDetServiceTagtb", div, id + "servicetag", "ServiceTag", "Service Tag:", "");
            result = result + MakeInputPair("JobLogDetTechlbl", "JobLogDetTechddl", "JobLogDetTechtb", "CONTACT", div, "", id + "tech", "13", "Service Rep: ", "Service Rep", 0, 10, "", "",true);

            result = result + @"$(" + div + @").append('</br>'); ";
            result = result + MakeTextArea("LogFirstOnLine", "JobLogTxtBox", div, id + "LogEntry", "LogEntry", "LogEntry: ", "", 1, 6);
            result = result + MakeTextArea("LogFirstOnLine", "JobLogTxtBox", div, id + "InternalNotes", "InternalNotes", "InternalNotes: ", "", 1, 6);
            #endregion
            return result + actions;

        }
        public string MakeJobLogEquipment(string div, string id, int AcctID, int LogID)
        {
            string result = "";
            result = result + @"$(" + div + @").append('</br>'); ";
            result = result + MakeLabel("LogFirstOnLine", div, id + "Title", "EQUIPMENT:");
            result = result + @"$(" + div + @").append('</br>'); ";
            result = result + MakeInputPair(@"JobLogDetEquiplbl", "JobLogDetEquipddl", "JobLogDetEquiptb", "EQUIP", div, "", id + "list", AcctID.ToString(), "Customer Equipment:", "CustomerEquipment", 0, 10, "", "",true);
            result = result + @"$(" + div + @").append('</br>'); ";

            result = result + MakeJobLogEquipTable(div, "tblEquipment", AcctID, 0, LogID);

            return result;
        }

        public string MakeEquipmentPage(int EquipID)
        {
            
            DRC_CustDevice Equip= new DRC_CustDevice();

            string actions = "";

             string Save = @"
                               

                                
                            $.ajax({
                                    url:'/DRCCustomer/EquipmentSave',
                                    data:{DeviceID:DeviceID, Manufact:$(tbequipmentmanmodelist).val(), Model:$(tbDequipmentmanmodelist).val(), SN:$(equipmentEQsn).val(), AssetTag:$(equipmentEQAsset).val(), DeviceType:$(tbequipmenttypelist).val(), CustID:CustID, Warranty:$(tbeqwarranty).val(), Contract:$(tbeqcontract).val(), Name:$(equipmentEQName).val(), Location:$(tbeqlocation).val()},
                                    type:'POST',
                                    traditional: true
                                    });


                            

                         ";//window.close();

            string Cancel = @" window.close(); ";
            string CustomData = "";
            string EQTypeRetrieveCustomInfo = @"$.post('/DRCCustomer/LoadDeviceCustomInfo',{DeviceTypeID:selvalequipmenttypelist});";
            string AddCustomData = @" $(btnAddCustomData).remove(); $.post('/DRCCustomer/AddCustomInfoToDevice', {DeviceID:DeviceID});";
            
            if (EquipID > 0)
            {
               Equip = DRCrepos.getSingleEquipment(EquipID);
                actions=actions+ @" var CustID=" + Equip.CustID + @"; var DeviceID="+Equip.DeviceID+@"; ";

            }
            
            string result = "";
            result = result + MakeButton2("btnSaveEquipment", "divEquipment", "btnclass", "SAVE", Save);
            result = result + MakeButton2("btnCancelEquipment", "divEquipment", "btnclass", "EXIT", Cancel);
            result = result + MakeButton2("btnCustomData", "divEquipment", "btnclass", "CUSTOM DATA", CustomData);
            //result = result + MakeButton2("btnDeviceTypeData", "divEquipment", "btnclass", "DEVICE TYPE DATA", DeviceTypeData);
            
            #region Equipment Details+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            string div = "divEquipmentDetails";
            string id = "equipment";
            result = result + @"$(" + div + @").append('</br>'); ";
            result = result + MakeInputBox("lblEQName", "tbEQName", div, id + "EQName", "Equipment_Name", "Equipment Name:", Equip.Name);
            result = result + @"$(" + div + @").append('</br>'); ";
            result = result + MakeInputPair(@"EQEquipTypelbl", "EQEquipTypeddl", "EQEquipTypetb", "EQUIPTYPE", div,DRCrepos.getEquipmentTypefromTypeID(Equip.DeviceType), id + "typelist", Equip.CustID.ToString(), "Equipment Type:", "Equipment Type", 0, 10, EQTypeRetrieveCustomInfo, EQTypeRetrieveCustomInfo,true);
            result = result + @"$(" + div + @").append('</br>'); ";
            result = result + MakeDDLDependentPair(@"EQManlbl", "EQManddl", "EQMantb", "EQModellbl", "EQModelddl", "EQModeltb", "MANoverMODEL", div,Equip.Manufact.ToString(),Equip.ModelID.ToString(), id + "manmodelist","", "Manufacture:", "Model", "Manufacture", "Model", 0, 10,true);
            result = result + @"$(" + div + @").append('</br>'); ";
            result = result + MakeInputBox("lblEQsn", "tbEQsn", div, id + "EQsn", "Serial_Number", "Serial Number:", Equip.SN);
            result = result + MakeInputBox("lblEQAsset", "tbEQAsset", div, id + "EQAsset", "Asset_ID", "Asset ID:", Equip.AssetTag);
            result = result + @"$(" + div + @").append('</br>'); ";
            result = result + MakeInputPair("EQLocationlbl", "EQLocationddl", "EQLocationtb", "EQLOCATION", div, DRCrepos.getDeviceLocationNamefromID(Equip.LocationID), "eqlocation", Equip.CustID.ToString(), "Location:", "Location", 0, 10,"","",true);
            result = result + @"$(" + div + @").append('</br>'); ";
            result = result + MakeInputPair("EQWarrantylbl", "EQWarrantyddl", "EQWarrantytb", "WARRANTY", div, Equip.WarrantyID.ToString(), "eqwarranty", "", "Warranty:", "Warranty", 0, 10,"","",true);
            result = result + MakeInputPair("EQContractlbl", "EQContractddl", "EQContracttb", "CONTRACT", div, Equip.ContractID.ToString(), "eqcontract", Equip.CustID.ToString(), "Contract:", "Contract", 0, 10,"","",true);
            #endregion

            
            
            string getdevicetypeinfo = @" window.open('/DRCCustomer/LoadDeviceTypeInfo/?DeviceID_InfoTypeID='+DeviceID+'_'+selvalDeviceInfoTypes); ";
            
            
           
            result = result + IE.MakeInputPair("DEVICEINFOTYPES", "divEquipment", "", "DeviceInfoTypes", "'background-color':'#000099','border-style':'none','font-size':'20px','color':'#FFFF99','overflow':'visible'", "'background-color':'#000099','border-style':'none','font-size':'20px','color':'#FFFF99','overflow':'visible'", "'background-color':'#000099','border-style':'none','font-size':'20px','color':'#FFFF99','overflow':'visible'", Equip.DeviceID.ToString(), "Device_Info_Types", 1, 20, getdevicetypeinfo, getdevicetypeinfo, false);
           
            result = result + actions;
            return result;
        }
        public string DisplayDeviceTypeInfo(List<string> Names,List<string> Data)
        {
            string result = "";
            string div = "divInfo";
            string actions = "";
            string Save = @"
                                var dinfocount=4; var dinfodata=new Array('"+ Data[0] + @"',DeviceID,'" + Data[2] + @"',InfoTypeID); 
                                while(dinfocount<=devinfocount)
                                {
                                    dinfodata[dinfocount]=$('#infodata'+dinfocount).val();
                                    dinfocount++;
                                }
                               
                               
                            $.ajax({
                                    url:'/DRCCustomer/DeviceTypeInfoSave',
                                    data:{DeviceInfoData:dinfodata},
                                    type:'POST',
                                    traditional: true
                                    });


                            

                         ";
            result = result + MakeButton2("btnSaveEquipment", "divbuttons", "btnclass", "SAVE", Save);
            actions = actions + @" var devinfocount=" + Names.Count + @"; ";
            
            
            for (int i = 4; i < Names.Count; i++)
            {
                if (Names[i] != "")
                {

                    result = result + MakeInputBox("", "InfoTypeInput", div, "infodata" + i, "", Names[i], Data[i]);
                    actions = actions + @" $(lblinfodata" + i + @").css({'color':'#66FFCC','font-size': '20px'}); $(infodata" + i + @").css({'background-color':'#000099','border-style':'none','font-size':'20px','color':'#FFFF99','overflow':'visible'}); ";
                    result = result + @" $(" + div + @").append('<br/>'); ";
                }

}

            
            result = result + actions;

            return result;
        }
        public string DisplayNewCustomInfo(int? DeviceID)//getcustominfo methods filter the typeid = 0
        {
            string result = "";
            List<string> CDNames = DRCrepos.getCustomInfoNamesList(DeviceID);
            List<string> CDData = DRCrepos.getCustomInfoData(DeviceID);
            string div = "divCustomData";
            string actions = @" newcustominfocount=" + CDNames.Count + @"; ";
            //Create device type data ui

            result = result + MakeLabel("", div, "DeviceSpecificlabel", DRCrepos.getEquipmentNamefromID(DeviceID) + @" Specific Info");
            result = result + @" $(" + div + @").append('<br/>'); ";
            result = result + MakeLabel("customNamelbl", div, "cnlabel", "NAME");
            result = result + MakeLabel("customDatalbl", div, "cdlabel", "DATA");
            result = result + @" $(" + div + @").append('<br/>'); ";
            for (int i = 4; i < CDNames.Count; i++)
            {
                result = result + MakeInputBox("", "", div, "custominfoname" + i, "", "", CDNames[i]);
                result = result + MakeInputBox("", "", div, "custominfodata" + i, "", "", CDData[i]);
                result = result + @" $(" + div + @").append('<br/>'); ";
            }
            result = result + actions;
            return result;
        }
        
        public string MakeQuickEquipment(int AcctID)
        {
            string EquipName = "";
            string SN = "";
            string div = "divnewEquipment";
            string id = "equipment";
            string Save = @"     
                                if(selvalequipmentmanmodelist<1)
                                { 
                                   alert($(tb" + id + @"manmodelist).val());
                                    $.post('/DRCCustomer/NewManCode',{CodeName:$(tb" + id + @"manmodelist).val()}); 
                                    $.post('/DRCCustomer/QuickEquipmentSave',{Manufact:selvalequipmentmanmodelist, ModelID:selvalDequipmentmanmodelist,SN:$(equipmentEQsn).val(), DeviceType:selvalequipmenttypelist, CustID:AcctID, Name:$(equipmentEQName).val()});
                         }
                                else
                                    {$.post('/DRCCustomer/QuickEquipmentSave',{Manufact:selvalequipmentmanmodelist, ModelID:selvalDequipmentmanmodelist,SN:$(equipmentEQsn).val(), DeviceType:selvalequipmenttypelist, CustID:AcctID, Name:$(equipmentEQName).val()});}
                                $(" + div + @").hide(); $(equipmentEQsn).val(''); $(equipmentEQName).val('');


                             ";
            string Cancel = @"$(" + div + @").hide(); $(equipmentEQsn).val(''); $(equipmentEQName).val(''); ";

            
            string result = "";
            result = result + MakeButton2("btnSaveEquipment", div, "btnclass", "SAVEEQUIPMENT", Save);
            result = result + MakeButton2("btnCancelEquipment", div, "btnclass", "CANCELEQUIPMENT", Cancel);
            result = result + @"$(" + div + @").append('</br>'); ";
            result = result + MakeInputBox("lblEQName", "tbEQName", div, id + "EQName", "Equipment_Name", "Equipment Name:", EquipName);
            result = result + IE.MakeInputPair(@"DEVICETYPES", div, "", id + "typelist", "", "","" , AcctID.ToString(), "Equipment_Type", 0, 10, "", "",false);
            
            result = result + @"$(" + div + @").append('</br>'); ";
            result = result + MakeDDLDependentPair(@"EQManlbl", "EQManddl", "EQMantb", "EQModellbl", "EQModelddl", "EQModeltb", "MANoverMODEL", div, "","" ,id + "manmodelist","", "Manufacture:", "Model", "Manufacture", "Model", 0, 10,true);
            result = result + @"$(" + div + @").append('</br>'); ";
            result = result + MakeInputBox("lblEQsn", "tbEQsn", div, id + "EQsn", "Serial_Number", "Serial Number:", SN);

            return result;
        }
        
        public string MakeContactDetails(int ContactID, int AcctID)
        {
            DRCMethods DRCMeth = new DRCMethods();
            string Result = "";
            string div = "divContactInfo";
            string id = "Contact";
            Result = @" var AcctID=" + AcctID + @"; ";
            DRC_Contact C = new DRC_Contact();
            if (ContactID > 0)//existing contact
            {
                C = DRCrepos.getContact(ContactID);
                Result = Result + MakeLabel("ContactHeader", "divContactInfo", "lblContactHeader", @"Editing Contact Info for " + C.FirstName + @" " + C.LastName + @" of " + DRCrepos.getAcctNamefromID(AcctID));
                C.ModifiedBy = DRCMeth.DRCuser(); C.ModifiedDateTime = DateTime.Now;
                Result = Result + @" document.title='" + C.FirstName + @" " + C.LastName + @"'; ";
            }
            else
            {
                Result = Result + @" document.title='New Contact for" + DRCrepos.getAcctNamefromID(AcctID) + @"' ;";
                Result = Result + MakeLabel("ContactHeader", "divContactInfo", "lblContactHeader", @"Creating New Contact  for " + DRCrepos.getAcctNamefromID(AcctID));
                C.AccountID = AcctID; C.Active = true; C.Address1 = "Street Address"; C.Address2 = "Suite"; C.AdminID = 0; C.City = "City"; C.ContactID = 0; C.Country = "Country"; C.CreatedBy = DRCMeth.DRCuser(); C.CreatedDateTime = DateTime.Now; C.Email1 = "Email@mail.com"; C.Email2 = "Email@mail.com"; C.FirstName = "Name"; C.HomePhone = @"(555)-555-555"; C.InstantMessage = "IM"; C.LastName = "Name"; C.MobileAddrSuffix1 = "txt.att.net"; C.MobileAddrSuffix2 = "txt.verizon.net"; C.MobileHost1 = "att.net"; C.MobileHost2 = "verizon.net"; C.MobilePhone1 = @"(555)-555-555"; C.MobilePhone2 = @"(555)-555-555"; C.NickName = "Name"; C.Notes1 = "Notes"; C.Notes2 = "Notes"; C.OtherPhone = @"(555)-555-555"; C.Pager = @"(555)-555-555"; C.SalesRepID = 0; C.SiteLoginName = "LoginName"; C.SiteLoginPassword = "LoginPassword"; C.Skipe = "Skipe"; C.State = "State"; C.Title = "Title"; C.WorkPhone = @"(555)-555-555"; C.ZipCode = "99999-9999"; C.Fax = @"(555)-555-555";
            }

            string Save = @" $.post('/DRCCustomer/UpdateContact', { CustID:AcctID, ContactID:ContactID, FN:$(FirstName).val(), LN:$(LastName).val(),T:$(Title).val(), AD1:$(StreetAddress).val(), AD2:$(Suite).val(), C:selvalcityContact, ST:selvalstateContact, ZIP:$(tbZipContact).val(), CO:selvalcountryContact, E1:$(tbEmail1Contact).val(), E2:$(tbEmail2Contact).val(), MP1:$(tbMobilephone1Contact).val(), MP2:$(tbMobilephone2Contact).val(), HP:$(tbHomePhoneContact).val(), WP:$(tbWorkPhoneContact).val(), OP:$(tbOtherPhoneContact).val(), IM:$(tbInstantMessageContact).val(), S:$(tbSkipeContact).val(), P:$(tbPagerContact).val(), NN:$(NickName).val(), FAX:$(tbFaxContact).val(), Note1:$(Note1).val(), Note2:$(Note2).val(), ARep:selvalAdminRep, SARep:selvalSalesRep, SURep:selvalSupportRep, LName:$(tbLoginNameContact).val(), LPass:$(tbpasswordContact).val(), MHost1:selvalMobileHost1, MHost2:selvalMobileHost2, MAdrS1:selvalMobileAdrrSuf1, MAdrS2:selvalMobileAdrrSuf2, Active:document.getElementById('cbactiveContact').checked}); ";

            string Cancel = @" window.close(); ";


            Result = Result + MakeButton2("btnSaveContact", div, "btnclass", "SAVE", Save);
            Result = Result + MakeButton2("btnCancelContact", div, "btnclass", "CANCEL", Cancel);
            Result = Result + @"$(" + div + @").append('</br>'); ";
            Result = Result + MakeCheckbox("cbContactActivelbl", "cbContactActivecb", div, "cbactive" + id, "Active:", "Active", "", Convert.ToBoolean(C.Active));
            Result = Result + MakeInputBox("lblFirstName", "tbFirstName", "divContactInfo", "FirstName", "FirstName", "FirstName", C.FirstName);
            Result = Result + MakeInputBox("lblLastName", "tbLastName", "divContactInfo", "LastName", "LastName", "LastName", C.LastName);
            Result = Result + MakeInputBox("lblNickName", "tbNickName", "divContactInfo", "NickName", "NickName", "NickName", C.NickName);
            Result = Result + MakeInputBox("lblTitle", "tbTitle", "divContactInfo", "Title", "Title", "Title", C.Title);
            Result = Result + MakeInputBox("lblStreetAddress", "tbStreetAddress", "divContactInfo", "StreetAddress", "StreetAddress", "StreetAddress", C.Address1);
            Result = Result + MakeInputBox("lblSuite", "tbSuite", "divContactInfo", "Suite", "Suite", "Suite", C.Address2);
            Result = Result + MakeInputPair("lblddlContactCity", "ddlContactCity", "tbddlContactCity", "CITYLIST", div, C.City, "city" + id, "", "CITY", "City", 0, 4, "", "",true);
            Result = Result + MakeInputPair("lblddlContactState", "ddlContactState", "tbddlContactState", "STATELIST", div, C.State, "state" + id, "", "STATE", "", 0, 4, "", "",true);
            Result = Result + MakeInputBox("lbltbContactZip", "tbContactZip", div, "tbZip" + id, "ZipCode", "ZIPCODE", C.ZipCode);
            Result = Result + MakeInputPair("lblddlContactCountry", "ddlContactCountry", "tbddlContactCountry", "COUNTRYLIST", div, C.Country, "country" + id, "", "COUNTRY", "", 0, 4, "", "",true);
            Result = Result + MakeInputBox("lbltbEmail1", "tbEmail1", div, "tbEmail1" + id, "Email1", "EMAIL1", C.Email1);
            Result = Result + MakeInputBox("lbltbEmail2", "tbEmail2", div, "tbEmail2" + id, "Email2", "EMAIL2", C.Email2);
            Result = Result + MakePhoneInput("tbMobilephone1", "lbltbMobilephone1", div, "tbMobilephone1" + id, "Mobilephone1", "Mobilephone1", C.MobilePhone1);
            Result = Result + MakePhoneInput("tbMobilephone2", "lbltbMobilephone2", div, "tbMobilephone2" + id, "Mobilephone2", "Mobilephone2", C.MobilePhone2);
            Result = Result + MakePhoneInput("tbWorkPhone", "lbltbWorkPhone", div, "tbWorkPhone" + id, "WorkPhone", "WorkPhone", C.WorkPhone);
            Result = Result + MakePhoneInput("tbHomePhone", "lbltbHomePhone", div, "tbHomePhone" + id, "HomePhone", "HomePhone", C.HomePhone);
            Result = Result + MakePhoneInput("tbOtherPhone", "lbltbOtherPhone", div, "tbOtherPhone" + id, "OtherPhone", "OtherPhone", C.OtherPhone);
            Result = Result + MakePhoneInput("tbFax", "lblFax", div, "tbFax" + id, "Fax", "Fax", C.Fax);
            Result = Result + MakeInputBox("lbltbInstantMessage", "tbInstantMessage", div, "tbInstantMessage" + id, "InstantMessage", "InstantMessage", C.InstantMessage);
            Result = Result + MakeInputBox("tbSkipe", "lbltbSkipe", div, "tbSkipe" + id, "Skipe", "Skipe", C.Skipe);
            Result = Result + MakePhoneInput("tbPager", "lbltbPager", div, "tbPager" + id, "Pager", "Pager", C.Pager);
            Result = Result + MakeTextArea("Note1lbl", "Note1box", div, "Note1", "Note1", "Note1: ", "", 1, 6);

            Result = Result + MakeTextArea("Note2lbl", "Note2box", div, "Note2", "Note2", "Note2: ", "", 1, 6);
            Result = Result + makeddlInputPair("AdminReplbl", "offset", "AdminReptb", "CONTACT", div, DRCrepos.getContact(C.AdminID).FirstName + @" " + DRCrepos.getContact(C.AdminID).LastName, "AdminRep", "13", "Assigned Admin Rep", "Assigned Admin Rep: ", 0, 10);
            Result = Result + makeddlInputPair("SalesReplbl", "offset", "SalesReptb", "CONTACT", div, DRCrepos.getContact(C.SalesRepID).FirstName + @" " + DRCrepos.getContact(C.SalesRepID).LastName, "SalesRep", "13", "Assigned Sales Rep", "Assigned Sales Rep: ", 0, 10);
            Result = Result + makeddlInputPair("SupportReplbl", "offset", "SupportReptb", "CONTACT", div, DRCrepos.getContact(C.SupportRepID).FirstName + @" " + DRCrepos.getContact(C.SupportRepID).LastName, "SupportRep", "13", "Assigned Support Rep", "Assigned Support Rep: ", 0, 10);
            Result = Result + MakeInputBox("lbltbLoginName", "tbLoginName", div, "tbLoginName" + id, "LoginName", "LoginName", C.SiteLoginName);
            Result = Result + MakeInputBox("lbltbpassword", "tbpassword", div, "tbpassword" + id, "Password", "Password", C.SiteLoginPassword);
            Result = Result + makeddlInputPair("MobileHost1lbl", "offset", "MobileHost1tb", "MOBILECARRIER", div, C.MobileHost1, "MobileHost1", "13", "MobileHost1", "MobileHost1: ", 0, 10);
            Result = Result + makeddlInputPair("MobileHost2lbl", "offset", "MobileHost2tb", "MOBILECARRIER", div, C.MobileHost2, "MobileHost2", "13", "MobileHost2", "MobileHost2: ", 0, 10);
            Result = Result + makeddlInputPair("MobileAdrrSuf1lbl", "offset", "MobileAdrrSuf1tb", "MOBILECARRIER", div, C.MobileHost2, "MobileAdrrSuf1", "13", "MobileAdrrSuf1", "MobileAdrrSuf1: ", 0, 10);
            Result = Result + makeddlInputPair("MobileAdrrSuf2lbl", "offset", "MobileAdrrSuf2tb", "MOBILECARRIER", div, C.MobileHost2, "MobileAdrrSuf2", "13", "MobileAdrrSuf2", "MobileAdrrSuf2: ", 0, 10);
            Result = Result + MakeCheckboxList("cblblRoles", "cbRoles", "cbListRolesTitle", div, "cblContactRoles", "Contact Roles", DRCrepos.getAllContactRolesJoined(C.ContactID));
            Result = Result + MakeInputBox("lbltbNewContactRole", "tbNewContactRole", div, "tbNewContactRole" + id, "NewContactRole", "New Contact Role:", "Need Logic");








            return Result;
        }
        public string MakeContactTable(int CustID, string div, string ID, string tblclass)
        {
            DRC_Contact[] ls = DRCrepos.ContactList(CustID);
            DRCMethods DRCMeth = new DRCMethods();
            
            string actions="";
            int count = 0;
            string Clist = @"";
            Clist = Clist + @"$("+div+@").append('<Table id="+ID+@" class="+tblclass+@"><tr><th>ID</th><th>First Name</th><th>Last Name</th><th>Mobile Number</th><th>Office Number</th><th>Email Address</th><th>Open Dialogs</th></tr>";
            while (count < ls.Count())
            {
                Clist = Clist + @"<tr><td class=checkselect id="+ID+count.ToString()+@"></td><td>" + DRCMeth.fixstring(ls[count].FirstName) + "</td><td>" + DRCMeth.fixstring(ls[count].LastName) + "</td><td>" + ls[count].MobilePhone1 + "</td><td>" + ls[count].WorkPhone + "</td><td>" + ls[count].Email1 + "</td><td id=Dialog"+ID+count.ToString()+@"></td></tr>";
                actions = actions + MakeButton2("btn" + ID + count.ToString(), ID + count.ToString(), "tblbtnclass", ls[count].ContactID.ToString(), @" $.post('/DRCCustomer/ContactSelected',{CID:" + ls[count].ContactID + @"}); ") + MakeButton2("btnDialog" + ID + count.ToString(), @"Dialog"+ID + count.ToString(), "tblbtnclass", "Dialogs", @" $.post('/DRCCustomer/ViewDialogs',{CID:" + ls[count].ContactID + @"}); ");
                count++;

            }
            Clist = Clist + @"</table>'); ";
            return Clist+actions;
        }
        public string MakeCustomerContacts(int CustID, string div)
        {
            string result = "";

           result=result+ MakeButton2("btnNewContact", div, "NewContactbtn", "NEW CONTACT", @"window.open('/DRCCustomer/NewContactDetails/?AcctID="+CustID+@"'); ");
            result = result + MakeContactTable(CustID, div, "tblContacts", "Contactstbl");

            return result;
        }
        
        public string MakeDialogLines(int ContactID)
        {
            string result = "";

            return result;
        }
        public string MakeDialog(int AcctID, string id, string div)
        {
            string result = "";
            string OpenNew=@"";
            string action="";
            List<DRC_DialogTable> DT = DRCrepos.getDialogsfromAccountID(AcctID);
            result=result+MakeLabel("DialogTitlelbl", div, id + "title", @"Dialogs for " + DRCrepos.getAcctNamefromID(AcctID));
            result=result+MakeButton2(id + "btnNew", div, "btnclass", "OpenNew", OpenNew);
            result = result + @"$(" + div + @").append('<table id=" + id + @"tblDialogs><tr><thead><th>ID<</th><th title=Open_or_Closed>Status</th><th>OpenDate</th><th>Description</th></tr>";
            foreach (DRC_DialogTable dt in DT)
            {
                result = result + @"<tr><td id=C1" + id + dt.DialogID + @"></td><td><input type=checkbox checked="+dt.OpenStatus+@"></td><td>" + dt.OpenDateTime.Value.ToString() + @"</td><td>" + dt.Description + @"</td></tr>";
                action = action + MakeButton2("btnC1" + id + dt.DialogID.ToString(), "C1" + id + dt.DialogID.ToString(), "", dt.DialogID.ToString(), "");
                
            }
            result = result + @"</table>'); ";

            return result+action;
        }
        public string MakeReturnMethodList(string rmclass)
        {
            string result = "<select id=ddlReturnMethods class=" + rmclass + @">";
            DRC_ReturnMethod[] rm = DRCrepos.getReturnMethods();
            foreach (DRC_ReturnMethod r in rm)
            {
                result = result + @"<option value=" + r.ReturnMethodID + @">" + r.Name + @"</option>";
            }
            result = result + @"</select>";
            return result;
        }

        public string MakePasswordInfo(int AcctID)
        {
            string div="divCustData";
            string result = MakeTablePages("Passwords", div, "", "Codes", "Customer Passwords", "Codescss", 0, 0, 20, AcctID);
            result = result + MakeButton2(@"btnNewPassWrd", div, "btnclass", "NEW", @"$.post('/DRCCustomer/NewPass',{AcctID:AcctID}); $(btnNewPassWrd).hide(); $(btnSavePwd).show(); ");
            result = result + MakeButton2("btnSavePwd", div, "btnclass", "SAVE", @"$(btnNewPassWrd).show(); $(btnSavePwd).hide();  $.post('/DRCCustomer/SaveNewPassRecord',{AcctID:AcctID,EntityTypeID:selvalPassWrdType,EntityName:$(tbPassWrdEntityName).val(),PassUsrName:$(tbPassWrdUserName).val(),Pass:$(tbPassWrd).val(),DeviceID:selvalddlDevice}); ");

            return result;
        }
        public string MakeNewPasswordRecord(int AcctID)
        {
            string result = "";
            string tbcssclass = "'background-color':'transparent','border-style':'none','font-size':'20px','color':'#FFFF99','overflow':'visible'";
            string ddlcssclass = "'background-color':'#000099','border-style':'none','font-size':'20px','color':'#FFFF99','overflow':'visible'";
            result = result + @" $(Codes).append('<tr><td id=passtypecell></td><td><input id=tbPassWrdEntityName class=passrecordinput></input></td><td><input id=tbPassWrdUserName class=passrecordinput></input></td><td><input id=tbPassWrd class=passrecordinput></input></td><td id=Devicecell></td></tr>'); ";
            result = result + IE.MakeInputPair("ENTITYTYPE", "passtypecell", "", "PassWrdType", tbcssclass, ddlcssclass, ddlcssclass, AcctID.ToString(), "Type_of_Password", 1, 10, "", "", false);
            result = result + IE.MakeInputPair("DEVICE", "Devicecell", "", "ddlDevice", tbcssclass, ddlcssclass, ddlcssclass, AcctID.ToString(), "Associated_Device", 1, 10, "", "", true);
            
                return result;
        }
        public string MakeEntityEdit(int EntityID)
        {
            string result = "";
            string controldiv = "divControls";
            result = result + MakeLabel("EntityLabel", controldiv, "lblType", @"Entity Type:");
            result = result + IE.MakeInputPair("ENTITYTYPE", controldiv, " ", "EntityType", "'background-color':'#000099','border-style':'none','font-size':'20px','color':'#FFFF99','overflow':'visible'", "'background-color':'#000099','border-style':'none','font-size':'20px','color':'#FFFF99','overflow':'visible'", "'background-color':'#000099','border-style':'none','font-size':'20px','color':'#FFFF99','overflow':'visible'",DRCrepos.getAccountIDFromEntityID(EntityID).ToString() , "Entity_type", 1, 10, "alert('option selected');", "alert('suboption selected');", false);

            result = result + MakeLabel("EntityLabel", controldiv, "lblParent", @"Parent Entity:");
            result = result + IE.MakeInputPair("ENTITY", controldiv, " ", "ParentEntity", "'background-color':'#000099','border-style':'none','font-size':'20px','color':'#FFFF99','overflow':'visible'", "'background-color':'#000099','border-style':'none','font-size':'20px','color':'#FFFF99','overflow':'visible'", "'background-color':'#000099','border-style':'none','font-size':'20px','color':'#FFFF99','overflow':'visible'", DRCrepos.getAccountIDFromEntityID(EntityID).ToString(),"Parent_Entity" , 1, 10, "alert('option selected');", "alert('suboption selected');", false);
            result = result + MakeLabel("EntityLabel", controldiv, "lblDevice", @"Device:");
            result = result + IE.MakeInputPair("DEVICE", controldiv, " ", "Device", "'background-color':'#000099','border-style':'none','font-size':'20px','color':'#FFFF99','overflow':'visible'", "'background-color':'#000099','border-style':'none','font-size':'20px','color':'#FFFF99','overflow':'visible'", "'background-color':'#000099','border-style':'none','font-size':'20px','color':'#FFFF99','overflow':'visible'", DRCrepos.getAccountIDFromEntityID(EntityID).ToString(), "Device", 1, 10, "alert('option selected');", "alert('suboption selected');", false);

            result = result + MakeLabel("EntityLabel", controldiv, "lblInfoType", @"Info Type:");
            result = result + IE.MakeInputPair("INFOTYPES", controldiv, " ", "EntityInfo", "'background-color':'#000099','border-style':'none','font-size':'20px','color':'#FFFF99','overflow':'visible'", "'background-color':'#000099','border-style':'none','font-size':'20px','color':'#FFFF99','overflow':'visible'", "'background-color':'#000099','border-style':'none','font-size':'20px','color':'#FFFF99','overflow':'visible'", DRCrepos.getAccountIDFromEntityID(EntityID).ToString(), "Entity_Info", 1, 10, "alert('option selected');", "alert('suboption selected');", false);

            result = result + @" $(" + controldiv + @").append('<br/>'); ";

            string PasswordClick = MakeInputBox("EntityLabel", "EntityTextBox", "divEntity", "UserName", "User_Name", "UserName:", "") + MakeInputBox("EntityLabel", "EntityTextBox", "divEntity", "PassWord", "Password", "Password:", "") + @" $(btnSavePassword).show(); $(btnCancelPassword).show(); $(btnSaveEntity).hide(); $(btnPassword).hide(); ";
        result=result+MakeButton2("btnPassword", controldiv, "btnclass", "PASSWORD", PasswordClick);

        
            
            string CancelPassword_clicked=@" $(divEntity).empty(); $(btnCancelPassword).hide(); $(btnSavePassword).hide(); $(btnSaveEntity).show(); $(btnPassword).show(); ";
        result=result+IE.MakeButton("btnCancelPassword", controldiv, "btnclass", "CANCEL PASSWORD", CancelPassword_clicked,true);
        string SavePassword_Clicked = @" $.post('/DRCCustomer/SavePassword',{EntityID:EntityID,UserName:$(UserName).val(),Password:$(PassWord).val()}); " + CancelPassword_clicked;
        result = result + IE.MakeButton("btnSavePassword", controldiv, "btnclass", "SAVE PASSWORD", SavePassword_Clicked, true);
            string SaveEntityClick=@" alert('button clicked!'); ";
        result=result+MakeButton2("btnSaveEntity", controldiv, "btnclass", "SAVE", SaveEntityClick);
            
            return result;
        }
        
        public string MakeTableHeaders(string div,string id,string[] Text, string[] titles)
        {
            string result = @"$("+div+@").append('<thead><TR>";
            for (int i = 0; i < Text.Count(); i++)
            {
                result = result + @"<th title=" + titles[i] + @">" + Text[i] + @"</th>";
            }
            
            
            return result;
        }
        public string MakeDeviceTable(int AcctID)
        {
            string result = "";
            string[] headers={"NAME","DT","MAN","Model","SN","AID","WAR","CID","LOC"};
            string[] titles={"","Device_Type","Manufacturer","","Serial_Number","Asset_Identification","Warranty_Type","Contract_ID","Location"};

            result = @"<table id=tblDevices>";
            result = result + MakeTableHeaders("divEquipment", "tblDevices", headers, titles);
            result = result + @"</tr><table>'); ";
            return result;
        }
        
        public string MakeAcctInfoEdit(int type, string div, string id, CustVendEmpInfo info)
        {
            string result = MakeGroupedInputBox(div, "tbStreet" + id, "Street", "STREET", info.Street, "relative") + MakeGroupedInputBox(div, "tbSuite" + id, "Suite", "SUITE", info.Suite, "relative") + MakeGroupedInputBox(div, "tbCity" + id, "City", "CITY", info.City, "relative") + makeGroupedddlInputPair(div, "state" + id, "STATE", "STATE", info.State, "relative", "STATELIST", "") + MakeGroupedInputBox(div, "tbZip" + id, "Postal Code", "POSTAL CODE", info.Zip, "relative") + MakeGroupedInputBox(div, "tbCountry" + id, "Country", "COUNTRY", info.Country, "relative") + MakeGroupedPhoneInput(div, "tbPhone" + id, "Phone", "PHONE", info.Phone, "relative") + MakeGroupedInputBox(div, "tbFax" + id, "FaxNumber", "FAX", info.Fax, "relative") + MakeGroupedInputBox(div, "tbEmail" + id, "EmailAddress", "EMAIL", info.Email, "relative") + MakeGroupedInputBox(div, "tbWebSite" + id, "WebsiteAddress", "WEBSITE", info.Website, "relative") + MakeGroupedTextArea(div, "taNotes" + id, "Enter_Notes", "NOTES", info.Notes, "relative");
            if (type == 9) { }//customer account, include terms etc.
            result = result + MakeButton("btnAcct" + id + @"Save", div, "SaveInfo", "SAVE") + MakeButton("btnAcct" + id + @"Cancel", div, "CancelInfo", "CLOSE");
            return result;
        }//Obsolete This
        
    }
    









}