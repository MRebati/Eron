import { Component, OnInit, AfterViewInit } from '@angular/core';

declare var $: any;

@Component({
  selector: 'app-user-dashboard',
  templateUrl: './user-dashboard.component.html',
  styleUrls: ['./user-dashboard.component.scss']
})
export class UserDashboardComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  // tslint:disable-next-line:use-life-cycle-interface
  ngAfterViewInit() {
    $(document).ready(function () {

      const sparklineCharts = function () {
        $('#sparkline1').sparkline([34, 43, 43, 35, 44, 32, 44, 52], {
          type: 'line',
          width: '100%',
          height: '50',
          lineColor: '#1ab394',
          fillColor: 'transparent'
        });

        $('#sparkline2').sparkline([32, 11, 25, 37, 41, 32, 34, 42], {
          type: 'line',
          width: '100%',
          height: '50',
          lineColor: '#1ab394',
          fillColor: 'transparent'
        });

        $('#sparkline3').sparkline([34, 22, 24, 41, 10, 18, 16, 8], {
          type: 'line',
          width: '100%',
          height: '50',
          lineColor: '#1C84C6',
          fillColor: 'transparent'
        });
      };

      let sparkResize;

      $(window).resize(function (e) {
        clearTimeout(sparkResize);
        sparkResize = setTimeout(sparklineCharts, 500);
      });

      sparklineCharts();

      const data1: number[][] = [
        [0, 4], [1, 8], [2, 5], [3, 10], [4, 4], [5, 16], [6, 5],
        [7, 11], [8, 6], [9, 11], [10, 20], [11, 10], [12, 13], [13, 4], [14, 7], [15, 8], [16, 12]
      ];
      const data2: number[][] = [
        [0, 0], [1, 2], [2, 7], [3, 4], [4, 11], [5, 4], [6, 2],
         [7, 5], [8, 11], [9, 5], [10, 4], [11, 1], [12, 5], [13, 2], [14, 5], [15, 2], [16, 0]
      ];

      const flotCharts = $('#flot-dashboard5-chart').length && $.plot($('#flot-dashboard5-chart'), [
        data1, data2
      ],
        {
          series: {
            lines: {
              show: false,
              fill: true
            },
            splines: {
              show: true,
              tension: 0.4,
              lineWidth: 1,
              fill: 0.4
            },
            points: {
              radius: 0,
              show: true
            },
            shadowSize: 2
          },
          grid: {
            hoverable: true,
            clickable: true,

            borderWidth: 2,
            color: 'transparent'
          },
          colors: ['#1ab394', '#1C84C6'],
          xaxis: {
          },
          yaxis: {
          },
          tooltip: false
        }
      );

    });

  }
}
