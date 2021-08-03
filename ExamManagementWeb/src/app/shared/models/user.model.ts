export type UserModel = {
  id: string;
  lastName: string;
  firstName: string;
  email: string;
  password: string;
  role: number;
  facultyId: string;
};

export * from './user.model';
