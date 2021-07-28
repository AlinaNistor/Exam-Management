import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-exam',
  templateUrl: './add-exam.component.html',
  styleUrls: ['./add-exam.component.scss'],
  encapsulation: ViewEncapsulation.None,
})

export class AddExamComponent implements OnInit {

  toggle1:boolean=false;
  toggle2:boolean=false;
  toggle3:boolean=false;
  toggle4:boolean=false;
  title: string = '';
  reactiveForm:FormGroup;
  submitted:boolean=false;
  constructor(private formBuilder: FormBuilder) {
    this.reactiveForm=this.formBuilder.group({
      title:new FormControl(null,[Validators.required]),
      professor:new FormControl(null,[Validators.required]),
      date:new FormControl(null,[Validators.required]),
      description:new FormControl(null,[Validators.required])
    },)
  }
  get f(){
    return this.reactiveForm.controls
  }
  onSubmit(){
    this.submitted=true;
    if(this.reactiveForm.invalid){
      return;
    }
  }
  changeType(input_field_password: { type: string; }, num: number){
    if(input_field_password.type=="title")
      input_field_password.type = "text";
    else
      input_field_password.type = "title";

    if(num == 1)
      this.toggle1 = !this.toggle1;
    if(num == 2)
      this.toggle2 = !this.toggle2;
    if(num == 3)
      this.toggle3 = !this.toggle3;
      if(num == 4)
      this.toggle4 = !this.toggle4;
  }

  ngOnInit(): void {
  }

}
