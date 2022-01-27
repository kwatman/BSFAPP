using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Imi.Project.Api.Infrastructure.Migrations
{
    public partial class ExpandDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "ImageURI",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LongDescription",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "BlogPosts",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "Content",
                value: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut auctor orci ac luctus pulvinar. Nam finibus a ante sed varius. Donec eget erat elit. Suspendisse lobortis suscipit leo. Morbi quis lorem lacus. Fusce elementum, mauris nec euismod finibus, sapien enim pharetra ex, ut porttitor risus sem nec ante. In dapibus libero ut mattis imperdiet. Nulla aliquam fermentum erat, non pellentesque enim vestibulum nec. Phasellus sit amet dui nunc. Integer placerat maximus sodales. Ut feugiat lorem quis eros dignissim, eu varius velit consectetur. Mauris pulvinar elementum orci vitae sodales. Morbi lacinia ultricies ligula id sollicitudin. Suspendisse consectetur nibh ac metus luctus facilisis.Suspendisse potenti. Nullam ut lorem auctor, lacinia mauris at, viverra est. Donec finibus odio eu leo efficitur, eget dapibus elit hendrerit. Aliquam eu rutrum justo. Pellentesque sagittis efficitur molestie. Fusce ut neque sit amet felis bibendum rutrum. Sed sit amet massa a urna volutpat sodales. Mauris elit nibh, ornare quis commodo a, pellentesque nec turpis. Nam ullamcorper nibh viverra turpis lobortis, laoreet eleifend erat lobortis. Integer sollicitudin metus tellus, et pretium nibh imperdiet ut.Aliquam cursus ligula sed erat volutpat accumsan. Fusce ut risus sollicitudin, tincidunt elit commodo, varius nunc. Vivamus fermentum eros at egestas tristique. Duis metus purus, auctor et congue vitae, finibus rhoncus arcu. Aenean lobortis, sem a rutrum commodo, urna velit posuere lacus, aliquam rutrum sapien lacus ac sem. Proin auctor, augue et tempor imperdiet, ante urna blandit tortor, vitae condimentum massa velit nec arcu. Mauris euismod magna id velit consectetur lacinia. Nam id sapien et justo tempor consectetur ac vitae massa.");

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "Content",
                value: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut auctor orci ac luctus pulvinar. Nam finibus a ante sed varius. Donec eget erat elit. Suspendisse lobortis suscipit leo. Morbi quis lorem lacus. Fusce elementum, mauris nec euismod finibus, sapien enim pharetra ex, ut porttitor risus sem nec ante. In dapibus libero ut mattis imperdiet. Nulla aliquam fermentum erat, non pellentesque enim vestibulum nec. Phasellus sit amet dui nunc. Integer placerat maximus sodales. Ut feugiat lorem quis eros dignissim, eu varius velit consectetur. Mauris pulvinar elementum orci vitae sodales. Morbi lacinia ultricies ligula id sollicitudin. Suspendisse consectetur nibh ac metus luctus facilisis.Suspendisse potenti. Nullam ut lorem auctor, lacinia mauris at, viverra est. Donec finibus odio eu leo efficitur, eget dapibus elit hendrerit. Aliquam eu rutrum justo. Pellentesque sagittis efficitur molestie. Fusce ut neque sit amet felis bibendum rutrum. Sed sit amet massa a urna volutpat sodales. Mauris elit nibh, ornare quis commodo a, pellentesque nec turpis. Nam ullamcorper nibh viverra turpis lobortis, laoreet eleifend erat lobortis. Integer sollicitudin metus tellus, et pretium nibh imperdiet ut.Aliquam cursus ligula sed erat volutpat accumsan. Fusce ut risus sollicitudin, tincidunt elit commodo, varius nunc. Vivamus fermentum eros at egestas tristique. Duis metus purus, auctor et congue vitae, finibus rhoncus arcu. Aenean lobortis, sem a rutrum commodo, urna velit posuere lacus, aliquam rutrum sapien lacus ac sem. Proin auctor, augue et tempor imperdiet, ante urna blandit tortor, vitae condimentum massa velit nec arcu. Mauris euismod magna id velit consectetur lacinia. Nam id sapien et justo tempor consectetur ac vitae massa.");

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "Content",
                value: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut auctor orci ac luctus pulvinar. Nam finibus a ante sed varius. Donec eget erat elit. Suspendisse lobortis suscipit leo. Morbi quis lorem lacus. Fusce elementum, mauris nec euismod finibus, sapien enim pharetra ex, ut porttitor risus sem nec ante. In dapibus libero ut mattis imperdiet. Nulla aliquam fermentum erat, non pellentesque enim vestibulum nec. Phasellus sit amet dui nunc. Integer placerat maximus sodales. Ut feugiat lorem quis eros dignissim, eu varius velit consectetur. Mauris pulvinar elementum orci vitae sodales. Morbi lacinia ultricies ligula id sollicitudin. Suspendisse consectetur nibh ac metus luctus facilisis.Suspendisse potenti. Nullam ut lorem auctor, lacinia mauris at, viverra est. Donec finibus odio eu leo efficitur, eget dapibus elit hendrerit. Aliquam eu rutrum justo. Pellentesque sagittis efficitur molestie. Fusce ut neque sit amet felis bibendum rutrum. Sed sit amet massa a urna volutpat sodales. Mauris elit nibh, ornare quis commodo a, pellentesque nec turpis. Nam ullamcorper nibh viverra turpis lobortis, laoreet eleifend erat lobortis. Integer sollicitudin metus tellus, et pretium nibh imperdiet ut.Aliquam cursus ligula sed erat volutpat accumsan. Fusce ut risus sollicitudin, tincidunt elit commodo, varius nunc. Vivamus fermentum eros at egestas tristique. Duis metus purus, auctor et congue vitae, finibus rhoncus arcu. Aenean lobortis, sem a rutrum commodo, urna velit posuere lacus, aliquam rutrum sapien lacus ac sem. Proin auctor, augue et tempor imperdiet, ante urna blandit tortor, vitae condimentum massa velit nec arcu. Mauris euismod magna id velit consectetur lacinia. Nam id sapien et justo tempor consectetur ac vitae massa.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ImageURI", "LongDescription", "ShortDescription" },
                values: new object[] { "kersenclafoutis.jpg", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut auctor orci ac luctus pulvinar. Nam finibus a ante sed varius. Donec eget erat elit. Suspendisse lobortis suscipit leo. Morbi quis lorem lacus. Fusce elementum, mauris nec euismod finibus, sapien enim pharetra ex, ut porttitor risus sem nec ante. In dapibus libero ut mattis imperdiet. Nulla aliquam fermentum erat, non pellentesque enim vestibulum nec. Phasellus sit amet dui nunc. Integer placerat maximus sodales. Ut feugiat lorem quis eros dignissim, eu varius velit consectetur. Mauris pulvinar elementum orci vitae sodales. Morbi lacinia ultricies ligula id sollicitudin. Suspendisse consectetur nibh ac metus luctus facilisis.", "Frans nagerecht van kersen in een lekker gebakken roommengsel uit de oven." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "ImageURI", "LongDescription", "ShortDescription" },
                values: new object[] { "marblecake.jpg", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut auctor orci ac luctus pulvinar. Nam finibus a ante sed varius. Donec eget erat elit. Suspendisse lobortis suscipit leo. Morbi quis lorem lacus. Fusce elementum, mauris nec euismod finibus, sapien enim pharetra ex, ut porttitor risus sem nec ante. In dapibus libero ut mattis imperdiet. Nulla aliquam fermentum erat, non pellentesque enim vestibulum nec. Phasellus sit amet dui nunc. Integer placerat maximus sodales. Ut feugiat lorem quis eros dignissim, eu varius velit consectetur. Mauris pulvinar elementum orci vitae sodales. Morbi lacinia ultricies ligula id sollicitudin. Suspendisse consectetur nibh ac metus luctus facilisis.", "Marmercake is de ultieme combinatie van een vanillecake en een chocoladecake." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "ImageURI", "LongDescription", "ShortDescription" },
                values: new object[] { "pumpkincookie.jpg", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut auctor orci ac luctus pulvinar. Nam finibus a ante sed varius. Donec eget erat elit. Suspendisse lobortis suscipit leo. Morbi quis lorem lacus. Fusce elementum, mauris nec euismod finibus, sapien enim pharetra ex, ut porttitor risus sem nec ante. In dapibus libero ut mattis imperdiet. Nulla aliquam fermentum erat, non pellentesque enim vestibulum nec. Phasellus sit amet dui nunc. Integer placerat maximus sodales. Ut feugiat lorem quis eros dignissim, eu varius velit consectetur. Mauris pulvinar elementum orci vitae sodales. Morbi lacinia ultricies ligula id sollicitudin. Suspendisse consectetur nibh ac metus luctus facilisis.", "Vanille vegan koekjes met pompoenglazuur" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "ImageURI", "LongDescription", "ShortDescription" },
                values: new object[] { "canneles.jpg", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut auctor orci ac luctus pulvinar. Nam finibus a ante sed varius. Donec eget erat elit. Suspendisse lobortis suscipit leo. Morbi quis lorem lacus. Fusce elementum, mauris nec euismod finibus, sapien enim pharetra ex, ut porttitor risus sem nec ante. In dapibus libero ut mattis imperdiet. Nulla aliquam fermentum erat, non pellentesque enim vestibulum nec. Phasellus sit amet dui nunc. Integer placerat maximus sodales. Ut feugiat lorem quis eros dignissim, eu varius velit consectetur. Mauris pulvinar elementum orci vitae sodales. Morbi lacinia ultricies ligula id sollicitudin. Suspendisse consectetur nibh ac metus luctus facilisis.", "Frans gebakje op smaak gebracht met rum, een culinaire specialiteit uit de streek rond Bordeaux" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "ImageURI", "LongDescription", "ShortDescription" },
                values: new object[] { "peppermintcookie.jpg", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut auctor orci ac luctus pulvinar. Nam finibus a ante sed varius. Donec eget erat elit. Suspendisse lobortis suscipit leo. Morbi quis lorem lacus. Fusce elementum, mauris nec euismod finibus, sapien enim pharetra ex, ut porttitor risus sem nec ante. In dapibus libero ut mattis imperdiet. Nulla aliquam fermentum erat, non pellentesque enim vestibulum nec. Phasellus sit amet dui nunc. Integer placerat maximus sodales. Ut feugiat lorem quis eros dignissim, eu varius velit consectetur. Mauris pulvinar elementum orci vitae sodales. Morbi lacinia ultricies ligula id sollicitudin. Suspendisse consectetur nibh ac metus luctus facilisis.", "Chocolade-kaneelkoekjes met vanille glazuur in Kertsthema." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "ImageURI", "LongDescription", "ShortDescription" },
                values: new object[] { "fondantcookie.jpeg", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut auctor orci ac luctus pulvinar. Nam finibus a ante sed varius. Donec eget erat elit. Suspendisse lobortis suscipit leo. Morbi quis lorem lacus. Fusce elementum, mauris nec euismod finibus, sapien enim pharetra ex, ut porttitor risus sem nec ante. In dapibus libero ut mattis imperdiet. Nulla aliquam fermentum erat, non pellentesque enim vestibulum nec. Phasellus sit amet dui nunc. Integer placerat maximus sodales. Ut feugiat lorem quis eros dignissim, eu varius velit consectetur. Mauris pulvinar elementum orci vitae sodales. Morbi lacinia ultricies ligula id sollicitudin. Suspendisse consectetur nibh ac metus luctus facilisis.", "Vanillekoekjes van het huis met roze rolfondant en het Glazed-logo." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "ImageURI", "LongDescription", "ShortDescription" },
                values: new object[] { "lemoncheesecake.jpg", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut auctor orci ac luctus pulvinar. Nam finibus a ante sed varius. Donec eget erat elit. Suspendisse lobortis suscipit leo. Morbi quis lorem lacus. Fusce elementum, mauris nec euismod finibus, sapien enim pharetra ex, ut porttitor risus sem nec ante. In dapibus libero ut mattis imperdiet. Nulla aliquam fermentum erat, non pellentesque enim vestibulum nec. Phasellus sit amet dui nunc. Integer placerat maximus sodales. Ut feugiat lorem quis eros dignissim, eu varius velit consectetur. Mauris pulvinar elementum orci vitae sodales. Morbi lacinia ultricies ligula id sollicitudin. Suspendisse consectetur nibh ac metus luctus facilisis.", "Kaastaart met citroencoulis op een bodem van caramelcrumble." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "ImageURI", "LongDescription", "ShortDescription" },
                values: new object[] { "doughnutcookie.jpg", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut auctor orci ac luctus pulvinar. Nam finibus a ante sed varius. Donec eget erat elit. Suspendisse lobortis suscipit leo. Morbi quis lorem lacus. Fusce elementum, mauris nec euismod finibus, sapien enim pharetra ex, ut porttitor risus sem nec ante. In dapibus libero ut mattis imperdiet. Nulla aliquam fermentum erat, non pellentesque enim vestibulum nec. Phasellus sit amet dui nunc. Integer placerat maximus sodales. Ut feugiat lorem quis eros dignissim, eu varius velit consectetur. Mauris pulvinar elementum orci vitae sodales. Morbi lacinia ultricies ligula id sollicitudin. Suspendisse consectetur nibh ac metus luctus facilisis.", "Glazed signature vanille-donutkoekjes met roze glazuur en sprinkles." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "ImageURI", "LongDescription", "ShortDescription" },
                values: new object[] { "marblecookie.jpg", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut auctor orci ac luctus pulvinar. Nam finibus a ante sed varius. Donec eget erat elit. Suspendisse lobortis suscipit leo. Morbi quis lorem lacus. Fusce elementum, mauris nec euismod finibus, sapien enim pharetra ex, ut porttitor risus sem nec ante. In dapibus libero ut mattis imperdiet. Nulla aliquam fermentum erat, non pellentesque enim vestibulum nec. Phasellus sit amet dui nunc. Integer placerat maximus sodales. Ut feugiat lorem quis eros dignissim, eu varius velit consectetur. Mauris pulvinar elementum orci vitae sodales. Morbi lacinia ultricies ligula id sollicitudin. Suspendisse consectetur nibh ac metus luctus facilisis.", "Hartvormige chocoladekoekjes met afwerking in rode rolfondant" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "ImageURI", "LongDescription", "ShortDescription" },
                values: new object[] { "applecrumble.jpg", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut auctor orci ac luctus pulvinar. Nam finibus a ante sed varius. Donec eget erat elit. Suspendisse lobortis suscipit leo. Morbi quis lorem lacus. Fusce elementum, mauris nec euismod finibus, sapien enim pharetra ex, ut porttitor risus sem nec ante. In dapibus libero ut mattis imperdiet. Nulla aliquam fermentum erat, non pellentesque enim vestibulum nec. Phasellus sit amet dui nunc. Integer placerat maximus sodales. Ut feugiat lorem quis eros dignissim, eu varius velit consectetur. Mauris pulvinar elementum orci vitae sodales. Morbi lacinia ultricies ligula id sollicitudin. Suspendisse consectetur nibh ac metus luctus facilisis.", "Verse crumble met stukjes appel en kaneel, heerlijk warm met een bolltje vanille-ijs." });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURI",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LongDescription",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "BlogPosts");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "Description",
                value: "Frans nagerecht van kersen in een lekker gebakken roommengsel uit de oven.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "Description",
                value: "Marmercake is de ultieme combinatie van een vanillecake en een chocoladecake.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "Description",
                value: "Vanille vegan koekjes met pompoenglazuur");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "Description",
                value: "Frans gebakje op smaak gebracht met rum, een culinaire specialiteit uit de streek rond Bordeaux");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "Description",
                value: "Vanille-kaneelkoekjes met vanille glazuur in Kertsthema.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                column: "Description",
                value: "Vanillekoekjes van het huis met roze rolfondant en het Glazed-logo.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                column: "Description",
                value: "Kaastaart met citroencoulis op een bodem van caramelcrumble.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                column: "Description",
                value: "Glazed signature vanille-donutkoekjes met roze glazuur en sprinkles.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                column: "Description",
                value: "Hartvormige chocoladekoekjes met afwerking in rode rolfondant");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                column: "Description",
                value: "Verse crumble met stukjes appel en kaneel, heerlijk warm met een bolltje vanille-ijs.");
        }
    }
}
