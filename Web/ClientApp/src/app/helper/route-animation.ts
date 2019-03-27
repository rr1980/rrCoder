import {
  transition,
  trigger,
  query,
  style,
  animate,
  group,
  animateChild,
  keyframes,
  state
} from '@angular/animations';


export const fadeInAnimation =
  trigger('fadeInAnimation', [
    // route 'enter' transition
    transition(':enter', [

      // styles at start of transition
      style({ opacity: 0 }),

      // animation and styles at end of transition
      animate('.3s', style({ opacity: 1 }))
    ]),
  ]);

export const slideInOutAnimation =
  trigger('slideInOutAnimation', [

    // end state styles for route container (host)
    state('*', style({
      // the view covers the whole screen with a semi tranparent background
      //position: 'fixed',
      //top: 0,
      //left: 0,
      //right: 0,
      //bottom: 0,
      backgroundColor: 'rgba(0, 0, 0, 0.8)'
    })),

    // route 'enter' transition
    transition(':enter', [

      // styles at start of transition
      style({
        // start with the content positioned off the right of the screen, 
        // -400% is required instead of -100% because the negative position adds to the width of the element
        right: '-400%',

        // start with background opacity set to 0 (invisible)
        backgroundColor: 'rgba(0, 0, 0, 0)'
      }),

      // animation and styles at end of transition
      animate('.5s ease-in-out', style({
        // transition the right position to 0 which slides the content into view
        right: 0,

        // transition the background opacity to 0.8 to fade it in
        backgroundColor: 'rgba(0, 0, 0, 0.8)'
      }))
    ]),

    // route 'leave' transition
    transition(':leave', [
      // animation and styles at end of transition
      animate('.5s ease-in-out', style({
        // transition the right position to -400% which slides the content out of view
        right: '-400%',

        // transition the background opacity to 0 to fade it out
        backgroundColor: 'rgba(0, 0, 0, 0)'
      }))
    ])
  ]);

//export const fader2 = trigger('routeAnimations', [
//  transition('* => *', [
//    query(
//      ':enter',
//      [style({ opacity: 0 })],
//      { optional: true }
//    ),
//    query(
//      ':leave',
//      [style({ opacity: 1 }), animate('0.3s', style({ opacity: 0 }))],
//      { optional: true }
//    ),
//    query(
//      ':enter',
//      [style({ opacity: 0 }), animate('0.3s', style({ opacity: 1 }))],
//      { optional: true }
//    )
//  ])
//]);

//export const stepper =
//  trigger('routeAnimations', [
//    transition('* <=> *', [
//      query(':enter, :leave', [
//        style({
//          position: 'absolute',
//          left: 0,
//          width: '100%',
//        }),
//      ],
//        { optional: true }),
//      group([
//        query(':enter', [
//          animate('2000ms ease', keyframes([
//            style({ transform: 'scale(0) translateX(100%)', offset: 0 }),
//            style({ transform: 'scale(0.5) translateX(25%)', offset: 0.3 }),
//            style({ transform: 'scale(1) translateX(0%)', offset: 1 }),
//          ])),
//        ],
//          { optional: true }),
//        query(':leave', [
//          animate('2000ms ease', keyframes([
//            style({ transform: 'scale(1)', offset: 0 }),
//            style({ transform: 'scale(0.5) translateX(-25%) rotate(0)', offset: 0.35 }),
//            style({ opacity: 0, transform: 'translateX(-50%) rotate(-180deg) scale(6)', offset: 1 }),
//          ])),
//        ],
//          { optional: true })
//      ]),
//    ])

//  ]);

//export const fader =
//  trigger('routeAnimations', [
//    transition('* <=> *', [
//      // Set a default  style for enter and leave
//      query(':enter, :leave', [
//        style({
//          position: 'absolute',
//          left: 0,
//          width: '100%',
//          opacity: 0,
//          transform: 'scale(0) translateY(100%)',
//        }),
//      ],
//        { optional: true }),
//      // Animate the new page in
//      query(':enter', [
//        animate('600ms ease', style({ opacity: 1, transform: 'scale(1) translateY(0)' })),
//      ],
//        { optional: true })
//    ]),
//  ]);

//export const slideInAnimation =
//  trigger('routeAnimations', [
//    transition('HomePage <=> AboutPage', [
//      style({ position: 'relative' }),
//      query(':enter, :leave', [
//        style({
//          position: 'absolute',
//          top: 0,
//          left: 0,
//          width: '100%'
//        })
//      ]),
//      query(':enter', [
//        style({ left: '-100%' })
//      ]),
//      query(':leave', animateChild()),
//      group([
//        query(':leave', [
//          animate('300ms ease-out', style({ left: '100%' }))
//        ]),
//        query(':enter', [
//          animate('300ms ease-out', style({ left: '0%' }))
//        ])
//      ]),
//      query(':enter', animateChild()),
//    ]),
//    transition('* <=> FilterPage', [
//      style({ position: 'relative' }),
//      query(':enter, :leave', [
//        style({
//          position: 'absolute',
//          top: 0,
//          left: 0,
//          width: '100%'
//        })
//      ]),
//      query(':enter', [
//        style({ left: '-100%' })
//      ]),
//      query(':leave', animateChild()),
//      group([
//        query(':leave', [
//          animate('200ms ease-out', style({ left: '100%' }))
//        ]),
//        query(':enter', [
//          animate('300ms ease-out', style({ left: '0%' }))
//        ])
//      ]),
//      query(':enter', animateChild()),
//    ])
//  ]);
