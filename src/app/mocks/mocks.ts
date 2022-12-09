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

const MANE: BroModel =
  {
    id: "3",
    nickname: "Mane",
    email: "mane@gmx.at",
    avatarUrl: "assets/mane.jpg"
  };

const TIEFI: BroModel =
  {
    id: "4",
    nickname: "Tiefi",
    email: "tiefi@gmx.at",
    avatarUrl: "assets/tiefi.jpg"
  };

const FLO: BroModel =
  {
    id: "5",
    nickname: "Flo",
    email: "floesche@gmx.at",
    avatarUrl: "assets/flo.jpg"
  };

const XANDL: BroModel =
  {
    id: "6",
    nickname: "Xandl",
    email: "xandl@gmx.at",
    avatarUrl: "assets/xandl.jpg"
  };

const HIRSCHI: BroModel =
  {
    id: "7",
    nickname: "Hirschi",
    email: "hirsch@gmx.at",
    avatarUrl: "assets/default.jpg"
  };

const EICHI: BroModel =
  {
    id: "8",
    nickname: "Eichi",
    email: "eichi@gmx.at",
    avatarUrl: "assets/default.jpg"
  };

const MINI: BroModel =
  {
    id: "9",
    nickname: "Mini",
    email: "mini@gmx.at",
    avatarUrl: "assets/mini.jpg"
  };

export const BROS: BroModel[] = [
  MATTL,
  MICHL,
  MANE,
  TIEFI,
  FLO,
  XANDL,
  EICHI,
  MINI,
  HIRSCHI
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
