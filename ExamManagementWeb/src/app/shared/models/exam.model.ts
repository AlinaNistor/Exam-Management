export type ExamModel ={
  id:string;
  facultyId:string;
  yearOfStudy: number,
  mandatory: number,
  name: string,
  headProfessor: string,
  date: string,
  examType: number,
  location: string,
  details: string,
  acceptsCommentaries: number
};

export * from "./exam.model";
