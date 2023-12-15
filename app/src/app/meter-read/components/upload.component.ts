import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { StatusResponse } from '../models/status-response';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent implements OnInit {

  constructor(private http: HttpClient, private sanitizer: DomSanitizer) { }

  selectedFile: File = null;
  isLoading = false;
  responseMessage = null;
  uploadUrl = 'https://localhost:7023/api/MeterRead/meter-reading-uploads';

  ngOnInit() {
  }

  onFileChanged(event) {
    this.selectedFile = event.target.files[0];
  }

  onUpload() {
    this.isLoading = true;
    const formData = new FormData();
    formData.append('file', this.selectedFile, this.selectedFile.name);

    this.http.post(this.uploadUrl, formData)
    .subscribe(
      (response: StatusResponse) => {
        this.isLoading = false;
        this.responseMessage = `<strong>Status:</strong> ${response.status}<br>
                                <strong>Success Count:</strong> ${response.successCount}<br>
                                <strong>Failure Count:</strong> ${response.failureCount}`;
      },
      (error) => {
        this.isLoading = false;
        this.responseMessage = `Error occurred during upload: ${error}`;
      }
    );
  } 
  
  getSafeHtml(html) {
    return this.sanitizer.bypassSecurityTrustHtml(html);
  }  
}
