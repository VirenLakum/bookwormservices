import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, FormBuilder } from "@angular/forms";
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

  // key that is used to access the data in local storageconst 
  STORAGE_KEY_USER = 'user';

  public maxDate: NgbDateStruct  = void 0;

  private isSubmitted:boolean = false;

  private giveAlert:boolean = false;

  private user : User =  new User();

  constructor(private calendar: NgbCalendar, private userServices:UserServicesService, 
    private dateFormatter:NgbDateParserFormatter, private router:Router, private formBuilder: FormBuilder) { 
    this.maxDate = this.calendar.getToday();
    console.log( "Date is " + this.maxDate)
  }

  registrationForm = this.formBuilder.group({
    name: this.formBuilder.control('', [Validators.required,Validators.minLength(3)]),
    email: this.formBuilder.control('', [Validators.required,Validators.email]),
    password: this.formBuilder.control('', [Validators.required,Validators.minLength(8)]),
    mobile: this.formBuilder.control('', [Validators.required,Validators.minLength(10)]),
    dob: this.formBuilder.control('', Validators.required),
    landmark : this.formBuilder.control('', Validators.required),
    city : this.formBuilder.control('', Validators.required),
    street : this.formBuilder.control('', Validators.required),
    pincode : this.formBuilder.control('', [Validators.required,Validators.minLength(6)]) 
  });


  ngOnInit() {

  }

  signup(receivedForm : FormGroup)
  {
    console.log("button clicked");
    this.isSubmitted = true;

    if (!receivedForm.valid)
    {
      console.log("validation failed")
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
        // insert updated array to local storage
        localStorage.setItem(this.STORAGE_KEY_USER, JSON.stringify(this.user));
        this.router.navigateByUrl('');
      }
      else
      {
        this.giveAlert = true;
      }
    });
  }

}
