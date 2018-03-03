using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using EventEngine.Interfaces.Events;
using EventEngine.Policies.Application.Events.Evaluators;
using EventEngine.Policies.Application.Events.EventData.Contextual;
using EventEngine.Policies.Application.Views;
using Xunit;

namespace UnitTests.Events.Evaluators
{
    public class PolicyCreationEvaluatorUnitTests
    {
        [Fact]
        public void WhenTheEventIsReceivedItIsEvaluated()
        {
            var expectedCustomerId = Guid.NewGuid().ToString();
            var expectedPolicyNumber = Guid.NewGuid().ToString();
            var target = new PolicyCreationEvaluator();
            var view = new Policy();
            var eventData = new PolicyCreationData(expectedCustomerId, expectedPolicyNumber);

            target.Evaluate(view, null, eventData);

            Assert.Equal(expectedCustomerId, view.CustomerId);
            Assert.Equal(expectedPolicyNumber, view.PolicyNumber);
        }
    }


    public class AddPremiumEvaluatorUnitTests
    {
        [Fact]
        public void WhenTheEventIsReceivedItIsEvaluated()
        {
            var fixture = new Fixture();
            var eventData = fixture.Create<AddPremiumData>();
            var target = new AddPremiumEvaluator();
            var view = new Policy();

            target.Evaluate(view, null, eventData);

            Assert.NotNull(view.UnallocatedPremiums);
            Assert.Equal(eventData.PartitionDetails.Count(), view.UnallocatedPremiums.Count);
           // Assert.Equal(expectedPremiumId, view.UnallocatedPremiums[0].PremiumId);
            void ProvePremium(Premium premium, int index)
            {
                Assert.Equal(eventData.FundSpread[premium.FundId]., premium.FundId);
                Assert.Equal(eventData.PartitionDetails.ElementAt(index).PartitionId, premium.);
                Assert.Equal(eventData.PartitionDetails.ElementAt(index).Amount, premium.Amount);
            }
            Assert.Collection(view.UnallocatedPremiums, premium => 
            {
                Assert.Equal()
            });
        }
    }
}