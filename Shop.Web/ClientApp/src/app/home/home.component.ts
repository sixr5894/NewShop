import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { calcPossibleSecurityContexts } from '@angular/compiler/src/template_parser/binding_parser';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';





@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  formGroup: FormGroup
  
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private router: Router) {
  }

  ngOnInit() {
    this.initForm();
  }

  initForm() {
    this.formGroup = new FormGroup(
      {
        login: new FormControl('', [Validators.required]),
        password: new FormControl('', [Validators.required])
      }
    )
  }

  loginProces() {
    var temp: AuthorizationModel = this.formGroup.value;
    var rslt:any;
    if (this.formGroup.valid) {
      this.http.post(this.baseUrl + 'Auth', temp).subscribe((result) => {
        rslt = result;
        sessionStorage.setItem("token", rslt.token)
        console.log(sessionStorage.getItem("token"))
        this.router.navigateByUrl('/fetch-data')
      })
    }
  }
}
export class AuthorizationModel {
  login: string;
  password: string;
}
