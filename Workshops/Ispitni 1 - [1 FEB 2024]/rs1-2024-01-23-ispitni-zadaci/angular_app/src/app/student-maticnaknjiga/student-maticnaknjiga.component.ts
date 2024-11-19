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
  studentID:any;
  student:any;
  upisi:any;
  akademskeGodine:any;
  ovjera_upis:any;

  ovjeriLjetni(s:any) {

  }

  upisLjetni(s:any) {

  }

  ovjeriZimski(s:any) {

  }

  ngOnInit(): void {
    this.GetStudent();
    this.GetUpisiStudenta();
    this.GetAkademskeGodine();
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

  private GetUpisiStudenta() {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/GetUpisi",  {
      headers:{
        'autentifikacija-token' : AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.vrijednost
      },

      params:{studentid:this.studentID},
      observe:'response'
    }).subscribe(response=>{
      this.upisi = response.body;
    });
  }

  NoviUpis() {
    this.novi_upis={
      studentid: this.studentID,
      evidentiraoid: AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.korisnickiNalogId
    }
  }

  private GetAkademskeGodine() {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/GetAllAkademske", MojConfig.http_opcije()).subscribe(x=>{
      this.akademskeGodine = x;
    });
  }

  DodajUpis() {
    this.httpKlijent.post(MojConfig.adresa_servera + "/DodajUpis", this.novi_upis, MojConfig.http_opcije())
      .subscribe((x: any) => {


        this.ngOnInit();
        this.novi_upis= null;
        porukaSuccess("Upis je dodan");
      },error => {
        porukaError("Upis nije moguće dodati za tu godinu ako nije označena obnova");
      });
  }

  OvjeriUpis() {
    this.httpKlijent.post(MojConfig.adresa_servera + "/OvjeriUpis", this.ovjera_upis, MojConfig.http_opcije())
      .subscribe((x: any) => {


        this.ngOnInit();
        this.ovjera_upis= null;
        porukaSuccess("Upis je ovjeren");
      },error => {
        porukaError("Upis nije ovjeren");
      });
  }

}
