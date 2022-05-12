import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { ImunizanteDetailsComponent } from './imunizante-details/imunizante-details.component';
import { ToastrModule } from 'ngx-toastr';
import { ImunizanteDetailFormComponent } from './imunizante-details/imunizante-detail-form/imunizante-detail-form.component';


@NgModule({
  declarations: [	
    AppComponent,
    ImunizanteDetailFormComponent,
    ImunizanteDetailsComponent
   ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
