export type LoginType = {
  email: string;
  password: string;
};

export type RegisterType = {
  name: string;
  email: string;
  password: string;
  confirmPassword: string;
};

export type NewsType = {
  id: number,
  title: string,
  image: string,
  content:string,
  date: string;
  authorId: number;
  authorName: number;
};

export type NewsPage = {
  news: NewsType[];
  currentPage: number;
  pages: number;
};

type Review = {
  user: string, 
  date: string, 
  content: string
}

export type MovieType = {
  id: number;
  title: string;
  image: string;
  description: string;
  release: string;
  rating: number;
  duration: number;
  country: string;
  budget: number;
  genres: string[];
  actors: string[];
  reviews: Review[];
};

export type LastMoviesType = {
  id: number,
  title: string,
  image: string,
  description:string,
  release: string;
  rating: number
};

export type AuthorType = {
  id: number;
  firstName: string;
  lastName: string;
};
