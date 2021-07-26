import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators, AbstractControl } from '@angular/forms';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.scss']
})

export class SettingsComponent implements OnInit {

  toggle1:boolean=false;
  toggle2:boolean=false;
  toggle3:boolean=false;
  password: string = '';
  reactiveForm:FormGroup;
  submitted:boolean=false;
  constructor(private formBuilder: FormBuilder) {
    this.reactiveForm=this.formBuilder.group({
      curentpassword:new FormControl(null,[Validators.required]),
      newpassword:new FormControl(null,[Validators.required,Validators.minLength(8)]),
      confirmpassword:new FormControl(null,[Validators.required])
    },
    {
      validators:this.MustMatch('newpassword','confirmpassword')
    })
  }
  get f(){
    return this.reactiveForm.controls
  }
  MustMatch(controlName: string, matchingControlName:string){
    return(formGroup:FormGroup)=>{
      const control = formGroup.controls[controlName];
      const matchingControl = formGroup.controls[matchingControlName];
      if(matchingControl.errors && !matchingControl.errors.MustMatch){
        return
      }
      if(control.value !== matchingControl.value){
        matchingControl.setErrors({MustMatch:true});
      }
      else{
        matchingControl.setErrors(null)
      }
    }
  }
  onSubmit(){
    this.submitted=true;
    if(this.reactiveForm.invalid){
      return;
    }
  }
  ngOnInit():void{}
  changeType(input_field_password: { type: string; }, num: number){
    if(input_field_password.type=="password")
      input_field_password.type = "text";
    else
      input_field_password.type = "password";

    if(num == 1)
      this.toggle1 = !this.toggle1;
    if(num == 2)
      this.toggle2 = !this.toggle2;
    if(num == 3)
      this.toggle3 = !this.toggle3;
  }
}
