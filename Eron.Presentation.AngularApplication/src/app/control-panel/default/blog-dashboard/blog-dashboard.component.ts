import { Component, OnInit, AfterViewInit, AfterViewChecked } from '@angular/core';
import { SelectListItem } from '../../../base/models/SelectList.model';
import { SelectListService } from '../../infrastructure/services/selectList.service';
import { NotificationService } from '../../../base/services/notification.service';
import { InvoiceModel } from '../../../website/financial/invoices/invoice.model';
import { PagedListResult } from '../../../base/models/PagedListResponse.model';
import { InvoiceService } from '../../../website/financial/invoices/invoice.service';
import { Subscription } from 'rxjs/Subscription';
import { InsightsService } from '../../../base/services/insights.service';

declare var $: any;

@Component({
  selector: 'app-blog-dashboard',
  templateUrl: './blog-dashboard.component.html',
  styleUrls: ['./blog-dashboard.component.scss']
})
export class BlogDashboardComponent implements OnInit, AfterViewInit {
  filter: any = {
    status: '',
    invoiceNumber: '',
    clientName: '',
    pageSize: 20,
    pageNumber: 1
  };

  lastMonthSales= 0;
  currentMonthSales= 0;
  currentDaySales= 0;
  clients= 0;
  customers= 0;
  pagesCount= 0;
  orderCount= 0;
  productsCount= 0;
  tariffCounts= 0;
  lastWeekSales= 0;
  currentWeekSales= 0;
  invoiceServiceSubscriber: Subscription;
  invoiceList: PagedListResult<InvoiceModel> = {
    totalCount: 0
  } as PagedListResult<InvoiceModel>;
  invoiceStatusList: SelectListItem[] = [];
  constructor(
    private selectListService: SelectListService,
    private notificationService: NotificationService,
    private invoiceService: InvoiceService,
    private insightService: InsightsService
  ) {
    this.invoiceService = invoiceService;
    this.selectListService.getSelectList('InvoiceType').subscribe(
      (response) => {
        this.invoiceStatusList = response;
      },
      (error) => {
        this.notificationService.serverError(error);
      }
    );

    this.getLastMonthSales();
    this.getCurrentMonthSales();
    this.getCurrentDaySales();
    this.getClients();
    this.getCustomers();
    this.getPagesCount();
    this.getOrdersCount();
    this.getProductsCounts();
    this.getTariffCounts();
    this.getLastWeekSales();
    this.getCurrentWeekSales();

    this.loadInvoices();
  }

  ngOnInit() {
  }

  loadInvoices() {
    this.invoiceServiceSubscriber = this.invoiceService.getAllInvoicesAsPagedList(this.filter).subscribe(
      (response) => {
        this.invoiceList = response;
        this.invoiceList.result.forEach(x => {
          x.progressString = (x.progress * (100 / 7)).toFixed(1).toString();
        });
      },
      (error) => {
        this.notificationService.serverError(error);
      }
    );
  }

  onFilterChange() {
    setTimeout(
      this.loadInvoices(),
      2000
    );
  }

  onPageChange($event) {
    this.invoiceServiceSubscriber.unsubscribe();
    this.filter.pageNumber = $event;
    this.loadInvoices();
  }

  ngAfterViewInit() {
    const insightService = this.insightService;

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

      const currentMonthSalesData: number[][] = [
        [0, 0],
        [1, 0],
        [2, 0],
        [3, 0],
        [4, 0],
        [5, 0],
        [6, 0],
        [7, 0],
        [8, 0],
        [9, 0],
        [10, 0],
        [11, 0],
        [12, 0],
        [13, 0],
        [14, 0],
        [15, 0],
        [16, 0],
        [17, 0],
        [18, 0],
        [19, 0],
        [20, 0],
        [21, 0],
        [22, 0],
        [23, 0],
        [24, 0],
        [25, 0],
        [26, 0],
        [27, 0],
        [28, 0],
        [29, 0],
        [30, 0],
      ];

      const lastMonthSalesData: number[][] = [
        [0, 0],
        [1, 0],
        [2, 0],
        [3, 0],
        [4, 0],
        [5, 0],
        [6, 0],
        [7, 0],
        [8, 0],
        [9, 0],
        [10, 0],
        [11, 0],
        [12, 0],
        [13, 0],
        [14, 0],
        [15, 0],
        [16, 0],
        [17, 0],
        [18, 0],
        [19, 0],
        [20, 0],
        [21, 0],
        [22, 0],
        [23, 0],
        [24, 0],
        [25, 0],
        [26, 0],
        [27, 0],
        [28, 0],
        [29, 0],
        [30, 0],
      ];
      insightService.getCurrentMonthSalesWithDayByDayDetails().subscribe(
        (response) => {

          insightService.getLastMonthSalesWithDayByDayDetails().subscribe(
            (response2) => {
              response.forEach(element => {
                currentMonthSalesData[ element.id ] = [element.id, element.value];
              });

              response2.forEach(element => {
                lastMonthSalesData[ element.id ] = [element.id, element.value];
              });

              $(document).ready(function () {
                const flotCharts = $('#flot-dashboard-chart').length && $.plot($('#flot-dashboard-chart'), [
                  currentMonthSalesData, lastMonthSalesData
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
              }
              );
            }
          );
        });

    });

  }

  getLastMonthSales(): any {
    this.insightService.getLastMonthSales().subscribe(
      (response) => {
        this.lastMonthSales = response;
      },
      (error) => {
        this.notificationService.serverError(error);
      }
    );
  }

  getCurrentMonthSales(): any {
    this.insightService.getCurrentMonthSales().subscribe(
      (response) => {
        this.currentMonthSales = response;
      },
      (error) => {
        this.notificationService.serverError(error);
      }
    );
  }

  getCurrentDaySales(): any {
    this.insightService.getCurrentDaySales().subscribe(
      (response) => {
        this.currentDaySales = response;
      },
      (error) => {
        this.notificationService.serverError(error);
      }
    );
  }

  getClients(): any {
    this.insightService.getClients().subscribe(
      (response) => {
        this.clients = response;
      },
      (error) => {
        this.notificationService.serverError(error);
      }
    );
  }

  getCustomers(): any {
    this.insightService.getCustomers().subscribe(
      (response) => {
        this.customers = response;
      },
      (error) => {
        this.notificationService.serverError(error);
      }
    );
  }

  getPagesCount(): any {
    this.insightService.getPagesCount().subscribe(
      (response) => {
        this.pagesCount = response;
      },
      (error) => {
        this.notificationService.serverError(error);
      }
    );
  }

  getOrdersCount(): any {
    this.insightService.getOrdersCount().subscribe(
      (response) => {
        this.orderCount = response;
      },
      (error) => {
        this.notificationService.serverError(error);
      }
    );
  }

  getProductsCounts(): any {
    this.insightService.getProductsCounts().subscribe(
      (response) => {
        this.productsCount = response;
      },
      (error) => {
        this.notificationService.serverError(error);
      }
    );
  }

  getTariffCounts(): any {
    this.insightService.getTariffCounts().subscribe(
      (response) => {
        this.tariffCounts = response;
      },
      (error) => {
        this.notificationService.serverError(error);
      }
    );
  }

  getLastWeekSales(): any {
    this.insightService.getLastWeekSales().subscribe(
      (response) => {
        this.lastWeekSales = response;
      },
      (error) => {
        this.notificationService.serverError(error);
      }
    );
  }

  getCurrentWeekSales(): any {
    this.insightService.getCurrentWeekSales().subscribe(
      (response) => {
        this.currentWeekSales = response;
      },
      (error) => {
        this.notificationService.serverError(error);
      }
    );
  }
}
