import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


export interface ScalusConfig {
  protocols: ProtocolMapping[];
  applications: ApplicationConfig[];
}

export interface ProtocolMapping {
  protocol: string;
  appId: string;
}

export interface ProtocolMappingDisplay {
  id: string;
  mapping: ProtocolMapping;
  configs: ApplicationConfig[];
}

export interface ApplicationConfig {
  id: string;
  name: string;
  description: string;
  platforms: string[];
  protocol: string;
  parser: ParserConfig;
  exec: string; 
  args: string[];
}

export interface ApplicationConfigDisplay {
  id: string;
  name: string;
  description: string;
  platforms: string;
  protocol: string;
  parser: ParserConfigDisplay;
  exec: string; 
  args: string;
}

export interface ParserConfig {
  id: string;
  options: string[];
  useDefaultTemplate: boolean;
  useTemplateFile: string;
  postProcessingExec: string;
  postProcessingArgs: string[];
}

export interface ParserConfigDisplay {
  id: string;
  options: string;
  useDefaultTemplate: boolean;
  useTemplateFile: string;
  postProcessingExec: string;
  postProcessingArgs: string;
}

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  private configUrl = 'api/Configuration'

  getConfig() {
    return this.http.get<ScalusConfig>(this.configUrl);
  }

  setConfig(config:ScalusConfig){
    return this.http.put<ScalusConfig>(this.configUrl, config);
  }
}
