﻿using GraphQlClient.Relay.Extensions;
using GraphQlClient.Relay.Samples;
using Xunit;

namespace GraphQlClient.Relay.Test
{
    public class GraphQueryStringBuilderTest
    {
        [Fact]
        public void BuildShouldCreateQueryStringIncludingAConnection()
        {
            var expectedQueryString = $"{{ addresses(first:5) {{ edges {{ cursor, node {{ type, name, number, otherInformation }} }}, pageInfo {{ hasNextPage, hasPreviousPage }} }} }}";
            var queryString = GraphQueryStringBuilder.Build<QueryRoot>(rootBuilder => rootBuilder
                .AddConnection(root => root.Addresses, 5, addressBuilder => addressBuilder
                    .IncludeAllScalars()
                )
            );

            Assert.Equal(expectedQueryString.Replace(" ", string.Empty), queryString.Trim().Replace(" ", string.Empty));
        }
    }
}
