import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from "@angular/forms";
import {NgbDateStruct, NgbCalendar, NgbDateParserFormatter} from '@ng-bootstrap/ng-bootstrap';
import { UserServicesService } from '../../services/user-services.service';
import { User } from '../../poco classes/user';
import { Router } from '@angular/router';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  public maxDate: NgbDateStruct  = void 0;

  private isSubmitted:boolean = false;

  private giveAlert:boolean = false;

  private user : User =  new User();

  registrationForm = new FormGroup({
    name: new FormControl('', Validators.required),
    email: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required),
    mobile: new FormControl('', Validators.required),
    dob: new FormControl('', Validators.required),
    landmark : new FormControl('', Validators.required),
    city : new FormControl('', Validators.required),
    street : new FormControl('', Validators.required),
    pincode : new FormControl('', Validators.required) 
  });

  constructor(private calendar: NgbCalendar, private userServices:UserServicesService, 
    private dateFormatter:NgbDateParserFormatter, private router:Router) { 
    this.maxDate = this.calendar.getToday();
    console.log( "Date is " + this.maxDate)
  }

  ngOnInit() {

  }

  signup(receivedForm : FormGroup)
  {
    console.log("button clicked");
    this.isSubmitted = true;

    if (receivedForm.valid)
    {
      return;
    }
    this.bindInputs(receivedForm);
  }

  bindInputs(form:FormGroup)
  {
    console.log("binding form");
    this.user.name = form.controls['name'].value;
    this.user.email = form.controls['email'].value;
    this.user.password = form.controls['password'].value;
    this.user.mobile = form.controls['mobile'].value;
    this.user.dob = this.dateFormatter.format(form.controls['dob'].value);
    this.user.landmark = form.controls['landmark'].value;
    this.user.city = form.controls['city'].value;
    this.user.street = form.controls['street'].value;
    this.user.pincode = form.controls['pincode'].value;

    this.registerUser();
  }

  registerUser()
  {
    console.log("sending user details");
    this.userServices.saveregistration(this.user).subscribe((data)=>
    { console.log(data);
      console.log("line 2");
      if (data.toString() === "true")
      {
        console.log('redirecting');
        this.router.navigateByUrl('');
      }
      else
      {
        this.giveAlert = true;
      }
    });
  }

}
