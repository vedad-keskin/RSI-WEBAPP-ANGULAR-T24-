import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";
import {AutentifikacijaHelper} from "../_helpers/autentifikacija-helper";

declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-student-maticnaknjiga',
  templateUrl: './student-maticnaknjiga.component.html',
  styleUrls: ['./student-maticnaknjiga.component.css']
})
export class StudentMaticnaknjigaComponent implements OnInit {

  constructor(private httpKlijent: HttpClient, private route: ActivatedRoute) {
    this.route.params.subscribe(params=>{
      this.studentID=<number>params['id'];
    })
  }

  novi_upis:any;
  student:any;
  studentID:any;



  ovjeriLjetni(s:any) {

  }

  upisLjetni(s:any) {

  }

  ovjeriZimski(s:any) {

  }

  ngOnInit(): void {
    this.GetStudent();
  }

  private GetStudent() {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/GetStudent",  {
      headers:{
        'autentifikacija-token' : AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.vrijednost
      },

      params:{studentid:this.studentID},
      observe:'response'
    }).subscribe(response=>{
      this.student = response.body;
    });
  }

}
