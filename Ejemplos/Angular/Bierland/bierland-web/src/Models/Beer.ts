export class Beer {
  id: number;
  name: string;
  description: string;
  qualification: number;

  constructor(id: number, name: string, description: string, qualification: number) {
    this.id = id;
    this.name = name;
    this.description = description;
    this.qualification = qualification;
  }
}
