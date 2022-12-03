import {BroModel, EventModel} from '../../api';

const MATTL: BroModel =
  {
    id: "1",
    nickname: "Mattl",
    email: "rauchmat@gmail.com",
    avatarUrl: "assets/mattl.jpg"
  };

const MICHL: BroModel =
  {
    id: "2",
    nickname: "Michl",
    email: "michl@gmx.at",
    avatarUrl: "assets/michl.jpg"
  };


export const BROS: BroModel[] = [
  MATTL,
  MICHL
]

export const EVENTS: EventModel[] = [
  {
    id: "1",
    title: "Bro Fixe November 2022",
    location: "Harry's Augustin",
    start: "12.11.2022 18:00",
    backgroundUrl: "assets/harrys-augustin.jpg",
    organizer: MATTL
  },
  {
    id: "2",
    title: "Bro Fixe Oktober 2022",
    location: "Gasthaus Stern",
    start: "17.10.2022 18:30",
    backgroundUrl: "assets/stern.jpg",
    organizer: MICHL
  },
];
